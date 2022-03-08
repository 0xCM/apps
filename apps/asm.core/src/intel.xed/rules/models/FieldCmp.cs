//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct FieldCmp
        {
            public readonly RuleOperator Operator;

            public readonly FieldValue Field;

            [MethodImpl(Inline)]
            public FieldCmp(RuleOperator op, FieldValue value)
            {
                Operator = op;
                Field = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field.IsNonEmpty;
            }

            public string Format()
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            public static FieldCmp Empty => new FieldCmp(0,FieldValue.Empty);
        }
    }
}