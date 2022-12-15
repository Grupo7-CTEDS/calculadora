﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace calculadora.Models
{
	public class Operation
	{
		public Guid Id { get; set; }
		public string Text { get; set; }
		public DateTime CreationTime { get; set; }

	}

}

