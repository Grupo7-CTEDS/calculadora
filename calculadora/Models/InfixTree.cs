using System;
using calculadora.Models;
using System.Collections.Generic;

namespace calculadora
{
	public class InfixTree
	{
		public InfixTree()
        {
		}

        // Function to create new node
        static Nptr newNode(char c)
        {
            Nptr n = new Nptr();
            n.data = c;
            n.left = n.right = null;
            return n;
        }

        // Function to build Expression Tree
        public static Nptr build(String s)
        {

            // Stack to hold nodes
            Stack<Nptr> stN = new Stack<Nptr>();

            // Stack to hold chars
            Stack<char> stC = new Stack<char>();
            Nptr t, t1, t2;

            // Prioritising the operators
            int[] p = new int[123];
            p['+'] = p['-'] = 1;
            p['/'] = p['*'] = 2;
            p['^'] = 3;
            p[')'] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {

                    // Push '(' in char stack
                    stC.Push(s[i]);
                }

                // Push the operands in node stack
                else if (char.IsDigit(s[i]))
                {
                    t = newNode(s[i]);
                    stN.Push(t);
                }
                else if (p[s[i]] > 0)
                {

                    // If an operator with lower or
                    // same associativity appears
                    while (stC.Count != 0 && stC.Peek() != '('
                        && ((s[i] != '^' && p[stC.Peek()] >= p[s[i]])
                            || (s[i] == '^' && p[stC.Peek()] > p[s[i]])))
                    {

                        // Get and remove the top element
                        // from the character stack
                        t = newNode(stC.Peek());
                        stC.Pop();

                        // Get and remove the top element
                        // from the node stack
                        t1 = stN.Peek();
                        stN.Pop();

                        // Get and remove the currently top
                        // element from the node stack
                        t2 = stN.Peek();
                        stN.Pop();

                        // Update the tree
                        t.left = t2;
                        t.right = t1;

                        // Push the node to the node stack
                        stN.Push(t);
                    }

                    // Push s[i] to char stack
                    stC.Push(s[i]);
                }
                else if (s[i] == ')')
                {
                    while (stC.Count != 0 && stC.Peek() != '(')
                    {
                        t = newNode(stC.Peek());
                        stC.Pop();
                        t1 = stN.Peek();
                        stN.Pop();
                        t2 = stN.Peek();
                        stN.Pop();
                        t.left = t2;
                        t.right = t1;
                        stN.Push(t);
                    }
                    stC.Pop();
                }
            }
            t = stN.Peek();
            return t;
        }

        static char calculate(Nptr root)
        {


            if (!char.IsDigit(root.left.data)) root.left.data = calculate(root.left);
            if (!char.IsDigit(root.right.data)) root.right.data = calculate(root.right);

            char value = '0';
            if (char.IsDigit(root.left.data) & char.IsDigit(root.right.data))
            {
                int op1 = int.Parse(root.left.data.ToString());
                int op2 = int.Parse(root.right.data.ToString());

                if (root.data == '+') value = Convert.ToChar(op1 + op2 + '0');
                if (root.data == '*') value = Convert.ToChar(op1 * op2 + '0');
                if (root.data == '/') value = Convert.ToChar(op1 / op2 + '0');


            }

            return value;


        }
    }
}

