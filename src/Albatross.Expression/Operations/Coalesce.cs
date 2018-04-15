﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// Prefix operation that return the first non null operand
	/// Operand Count: 1 to infinite
	/// Operand Type: any
	/// Example: Coalesce(null, 1, 2, 3) will return 1
	/// </summary>
	[ParserOperation]
	public class Coalesce : PrefixOperationToken {

		public override string Name { get { return "Coalesce"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			foreach (object obj in list) {
				if (obj != null) {
					return obj;
				}
			}
			return null;
		}
	}
}
