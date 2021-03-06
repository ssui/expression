﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Exceptions {
	public class MissingVariableException : Exception {
		public MissingVariableException(string name) 
			: base(string.Format("Variable {0} was not found", name)) {
			
			VariableName = name;
		}
		public string VariableName { get; private set; }
	}
}
