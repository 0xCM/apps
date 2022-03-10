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
            public readonly FieldValue Left;

            public readonly RuleOperator Operator;

            public readonly FieldValue Right;

            [MethodImpl(Inline)]
            public FieldCmp(FieldValue value, RuleOperator op, FieldValue right)
            {
                Left = value;
                Operator = op;
                Right = right;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Left.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Left.IsNonEmpty;
            }

            public string Format()
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            public static FieldCmp Empty => new FieldCmp(FieldValue.Empty,0,FieldValue.Empty);
        }
    }
}