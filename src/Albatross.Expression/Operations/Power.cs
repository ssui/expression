﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an power operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>base : decimal</description></item>
	///		<item><description>operand : decimal</description></item>
	/// </list>
	/// <para>Output Type: decimal</para>
	/// </summary>
	[ParserOperation]
	public class Power : InfixOperationToken {

		public override string Name { get { return "^"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 300; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) { return null; }

			if(a is decimal && b is decimal){
				return Convert.ToDecimal(Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b)));
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
