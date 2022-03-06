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
        public readonly struct CriterionSpec
        {
            public readonly FieldKind Kind;

            public readonly RuleOperator Operator;

            public readonly FieldDataType DataType;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            internal CriterionSpec(FieldKind kind, RuleOperator op, FieldDataType type, ulong data)
            {
                Kind = kind;
                Operator = op;
                DataType = type;
                Data = data;
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();
        }

    }
}