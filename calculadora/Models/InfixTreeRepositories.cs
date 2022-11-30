using System;
using System.Collections.Generic;

namespace calculadora.Models
{
	public class InfixTreeRepositories
	{
		public InfixTreeRepositories()
		{

		}
   

        public static List<char> operations = new List<char>()
        {
            '+',
            '*',
            '-',
            '/',
            '^',
            's', //seno
            'c', //cosseno
            'm', //mod
            'f' // fatorial

        };

        public static int opCentral(String s)
        {

            int parentesesAbertos = 0;
            int p = 0;

            while (p < s.Length)
            {
                if (s[p] == '(') parentesesAbertos++;
                if (s[p] == ')') parentesesAbertos--;
                if (parentesesAbertos == 0 & InfixTreeRepositories.operations.Contains(s[p])) return p;

                p++;
            }

            return -1;
        }
        
        private static double factorial(double n){
            if (n <= 1.0) return 1;
            else return n*factorial(n-1);
        }

        //methods for building the string for non trivial operators
        public static void add_sine(ref string s){
            s = s + '1' + 's';
        }
        public static void add_cos(ref string s){
            s = s + '1' + 'c';
        }



      


    }
}

