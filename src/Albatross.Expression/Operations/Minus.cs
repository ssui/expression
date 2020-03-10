using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Minus : InfixOperationToken {
		
		public override string Name { get { return "-"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) {
				return null;
			}else if(a is decimal && b is decimal){
				return (decimal)a - (decimal)b;
			}else if(a is DateTime && b is decimal){
				return ((DateTime)a).AddDays(-1 * Convert.ToDouble(b));
			} else {
				throw new UnexpectedTypeException(a.GetType());
			}
		}
	}
}
