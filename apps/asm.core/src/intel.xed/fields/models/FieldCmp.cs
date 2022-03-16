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
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly FieldValue Value;

            [MethodImpl(Inline)]
            public FieldCmp(FieldKind left, RuleOperator op, FieldValue right)
            {
                Field = left;
                Operator = op;
                Value = right;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Value.IsEmpty;

            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field !=0 || Value.IsNonEmpty;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static FieldCmp Empty => new FieldCmp(0,0,FieldValue.Empty);
        }
    }
}