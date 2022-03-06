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

            public readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldCmp(FieldKind field, RuleOperator op, ulong data)
            {
                Field = field;
                Operator = op;
                Data = data;
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            public static FieldCmp Empty => new FieldCmp(FieldKind.INVALID,0,0);
        }
    }
}