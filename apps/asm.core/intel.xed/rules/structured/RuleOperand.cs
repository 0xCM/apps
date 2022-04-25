//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly record struct RuleOperand<T> : ILogicOperand<T>
            where T : unmanaged
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
        }
    }
}