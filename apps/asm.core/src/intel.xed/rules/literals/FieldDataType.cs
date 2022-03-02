//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct FieldDataType
        {
            public readonly FieldDataKind Kind;

            public readonly ushort Width;

            [MethodImpl(Inline)]
            public FieldDataType(FieldDataKind kind, ushort width)
            {
                Kind = kind;
                Width = width;
            }

            [MethodImpl(Inline)]
            public static implicit operator FieldDataType((FieldDataKind kind, ushort width) src)
                => new FieldDataType(src.kind, src.width);
        }
    }
}