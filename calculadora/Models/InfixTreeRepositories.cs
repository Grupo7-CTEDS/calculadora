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
            '^'
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
    }
}

