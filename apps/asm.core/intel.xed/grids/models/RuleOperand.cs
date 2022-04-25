//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedGrids
    {
        public readonly record struct RuleOperand : ILogicOperand<LogicValue>
        {
            public readonly Nonterminal Rule;

            public readonly RuleOperator Operator;

            public readonly LogicValue Value;

            [MethodImpl(Inline)]
            public RuleOperand(RuleName rule, RuleOperator op, LogicValue value)
            {
                Rule = rule;
                Operator = op;
                Value = value;
            }

            LogicValue ILogicOperand<LogicValue>.Value
                => Value;

            RuleOperator ILogicOperand.Operator
                => Operator;
        }
    }
}