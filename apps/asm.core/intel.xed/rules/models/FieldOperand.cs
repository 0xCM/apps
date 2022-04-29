//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct FieldOperand : ILogicOperand<LogicValue>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly LogicValue Value;

            [MethodImpl(Inline)]
            public FieldOperand(FieldKind field, RuleOperator op, LogicValue value)
            {
                Field = field;
                Operator = op;
                Value = value;
            }

            RuleOperator ILogicOperand.Operator
                => Operator;

            LogicValue ILogicOperand<LogicValue>.Value
                => Value;
        }
    }
}