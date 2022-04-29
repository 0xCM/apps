//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct RuleOperand<T> : ILogicOperand<T>
            where T : unmanaged, ILogicValue<T>
        {
            public readonly Nonterminal Rule;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public RuleOperand(RuleName rule, RuleOperator op, T value)
            {
                Rule = rule;
                Operator = op;
                Value = value;
            }

            T ILogicOperand<T>.Value
                => Value;

            RuleOperator ILogicOperand.Operator
                => Operator;

            [MethodImpl(Inline)]
            public static implicit operator RuleOperand(RuleOperand<T> src)
                =>  new RuleOperand(src.Rule, src.Operator, LogicValue.untype(src.Value));
        }
    }
}