﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an equal check</para>
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
	public class Equal : ComparisonInfixOperation {

		public override string Name { get { return "="; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult == 0;
		}
	}
}
