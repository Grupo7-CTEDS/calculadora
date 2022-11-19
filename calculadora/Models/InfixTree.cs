using System;
using calculadora.Models;
using System.Collections.Generic;

namespace calculadora
{
    public class InfixTree
    {


        // Function to build Expression Tree
        public static void build(String s, ref No root)
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

                build(s.Substring(p + 2, comprimento - 2), ref no_d);//envia os parenteses das bordas
                root.right = no_d;

            }
            else if (char.IsDigit(s[p + 1]))
            {
                int digitos = 0;

                while (char.IsDigit(s[p + 1 + digitos]))
                {
                    digitos++;
                    if (p + 1 + digitos >= s.Length - 1) break;
                }


                no_d.number = Int32.Parse(s.Substring(p + 1, digitos));
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


                build(s.Substring(p - comprimento - 1, comprimento), ref no_e);
                root.left = no_e;

            }

            else if (char.IsDigit(s[p - 1]))
            {
                int contador = p - 1;
                int digitos = 0;


                while (char.IsDigit(s[contador]))
                {
                    digitos++;
                    if (contador == 0) break;


                    contador--;


                }


                no_e.number = Int32.Parse(s.Substring(contador, digitos));
                root.left = no_e;




            }
        }
        static void calculate(ref No root)
        {



            if (root.left.operation != null) calculate(ref root.left);
            if (root.right.operation != null) calculate(ref root.right);


            if (root.left.operation == null & root.right.operation == null)
            {
                int op1 = root.left.number;
                int op2 = root.right.number;

                if (root.operation == '+') root.number = op1 + op2;
                else if (root.operation == '*') root.number = op1 * op2;
                else if (root.operation == '/') root.number = op1 / op2;
                root.operation = null;

            }


        }



    }
}

