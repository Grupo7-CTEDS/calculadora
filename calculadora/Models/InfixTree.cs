using System;
using calculadora.Models;
using System.Collections.Generic;

namespace calculadora
{
    public class InfixTree
    {


        // Function to build Expression Tree
       public static void build(String s,ref No root)
        {
            int p = InfixTreeRepositories.opCentral(s);
            root.operation = s[p];


            No no_d = new No();
            if (s[p + 1] == '(')
            {
               
                int contador = 0;
                int comprimento = 0;
                
                do
                {

                    if (s[p + 1 + comprimento] == '(')
                    {
                        contador++;
                    }
                    if (s[p + 1 + comprimento] == ')')
                    {
                        contador--;
                    }

                    comprimento++;

                } while (contador != 0);

                build(s.Substring(p + 2, comprimento-2), ref no_d);//envia os parenteses das bordas
                root.right = no_d;

            }
            else if (char.IsDigit(s[p + 1]))
            {
                int digitos = 0;

                    while (p + 1 + digitos < s.Length && (char.IsNumber(s[p + 1 + digitos]) | s[p+1+digitos] == '.'))
                    {
                    digitos++;
                    
                    }
                

                no_d.number = Double.Parse(s.Substring(p+1, digitos));
                root.right = no_d;

            }

            No no_e = new No();
            if (s[p - 1] == ')')
            {
                

                int contador = 0;
                int comprimento = 0;

                do
                {
                    if (s[p - 1 - comprimento] == ')')
                    {
                        contador++;
                    }
                    if (s[p - 1 - comprimento] == '(')
                    {
                        contador--;
                    }


                    comprimento++;
                } while (contador != 0);
                comprimento = comprimento - 2;


                build(s.Substring(p-comprimento-1, comprimento), ref no_e);
                root.left = no_e;

            }

            else if (char.IsDigit(s[p - 1]))
            {
                int contador = p - 1;
                int digitos = 0;


                while (char.IsDigit(s[contador]) | s[contador] == '.')
                {
                    digitos++;
                    if (contador == 0) break;


                    contador--;
                    

                }


                no_e.number = Double.Parse(s.Substring(contador,digitos));
                root.left = no_e;




            }
        }
         public static void calculate(ref No root)
        {



            if (root.left.operation != null) calculate(ref root.left);
            if (root.right.operation != null) calculate(ref root.right);


            if (root.left.operation == null & root.right.operation == null)
            {
                double op1 = root.left.number;
                double op2 = root.right.number;

                if (root.operation == '+') root.number = op1 + op2;
                else if (root.operation == 'x') root.number = op1 * op2;
                else if (root.operation == '÷') root.number = op1 / op2;
                else if (root.operation == '^') root.number = Math.Pow(op1, op2);
                else if (root.operation == 's') root.number = Math.Sin(op2);
                else if (root.operation == 'c') root.number = Math.Cos(op2);
                else if (root.operation == 'L') root.number = Math.Log10(op2);
                else if (root.operation == 'l') root.number = Math.Log(op2);
                else if (root.operation == 'm') root.number = op1%op2;
                else if (root.operation == 'f') root.number = InfixTreeRepositories.factorial(op2);
                root.operation = null;

            }


        }


    }
}

