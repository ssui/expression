using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an plus operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : decimal</description></item>
	///		<item><description>Operrand2 : decimal</description></item>
	/// </list>
	/// <para>Output Type: decimal</para>
	/// </summary>
	[ParserOperation]
	public class Plus : InfixOperationToken {

		public override string Name { get { return "+"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) { return null; }
			
			if (a is decimal && b is decimal) {
				return (decimal)a + (decimal)b;
			}else if(a is DateTime && b is decimal){
				return ((DateTime)a).AddDays(Convert.ToDouble(b));
			}else if(a is string || b is string){
				return string.Format("{0}{1}", a, b);
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
