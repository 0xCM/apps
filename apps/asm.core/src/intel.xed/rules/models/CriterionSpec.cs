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

            readonly ByteBlock32 Storage;

            [MethodImpl(Inline)]
            internal CriterionSpec(FieldKind kind, RuleOperator op, FieldDataType type, ReadOnlySpan<byte> data)
            {
                Kind = kind;
                Operator = op;
                DataType = type;
                Storage = data;
            }

            public ReadOnlySpan<byte> Data
            {
                [MethodImpl(Inline)]
                get => Storage.Bytes;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}