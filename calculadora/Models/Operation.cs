using System;
namespace calculadora.Models
{
	public class Operation
	{
		public string op;
		public DateTime creationTime;

		public Operation(string operation)
		{
			op = operation;
			creationTime = DateTime.Now;
		}
	}
}

