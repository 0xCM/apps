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
        public readonly record struct FieldOperand<T> : ILogicOperand<T>
            where T : unmanaged
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly T Value;

            [MethodImpl(Inline)]
            public FieldOperand(FieldKind field, RuleOperator op, T value)
            {
                Field = field;
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