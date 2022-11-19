using System;
namespace calculadora.Models
{
    public class No
    {
        public Nullable<char> operation;
        public No left, right;
        public double number;

        public No()
        {
            operation = null;
            left = null;
            right = null;
            number = 0;
        }
    };
}

