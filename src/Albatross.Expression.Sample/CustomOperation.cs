using Albatross.Expression.Operations;
using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Linq;

namespace Albatross.Expression.Sample {
	[ParserOperation]
	public class Sin : PrefixOperationToken {
		public override IToken Clone() {
			return new Sin();
		}
		public override int MaxOperandCount => 1;
		public override int MinOperandCount => 1;
		public override string Name => "custom_sin";
		public override bool Symbolic => false;
		public override object EvalValue(Func<string, object> context) {
			decimal input = base.GetOperands<decimal>(context).First<decimal>();
			return Convert.ToDecimal(Math.Sin(Convert.ToDouble(input)));
		}
	}

	[ParserOperation]
	public class AbsoluteMax : PrefixOperationToken {

		public override string Name { get { return "max"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			var items = GetOperands<decimal>(context);
			decimal max = items.First();
			foreach (var item in items) {
				if (max < Math.Abs(item)) {
					max = Math.Abs(item);
				}
			}
			return max;
		}
	}

	[TestFixture]
	public class CustomOperation {

		[TestCase("custom_sin(pi()/2)", ExpectedResult = 1)]
		public object TestSinOperation(string expression) {
			Factory factory = new Factory().Register(this.GetType().Assembly);
			return factory.Create().Compile(expression).EvalValue(null);
		}

		[TestCase("max(-1, -2, -3)", ExpectedResult = -1)]
		public object TestDefaultMaxOperation(string expression) {
			Factory factory = new Factory();
			return factory.Create().Compile(expression).EvalValue(null);
		}

		/// <summary>
		/// The default max operation is replaced by class <see cref="Albatross.Expression.Sample.AbsoluteMax"/> using the <see cref="Albatross.Expression.Factory.Replace{T, K}"/> function.
		/// </summary>
		[TestCase("max(-1, -2, -3)", ExpectedResult = 3)]
		public object TestAbsoluteMaxOperation(string expression) {
			Factory factory = new Factory().Replace<Max, AbsoluteMax>();
			return factory.Create().Compile(expression).EvalValue(null);
		}
	}
}
