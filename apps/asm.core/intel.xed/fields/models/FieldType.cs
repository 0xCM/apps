//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly record struct FieldType
        {
            const byte LastKind = (byte)FieldDataKind.InstClass;

            readonly byte Data;

            [MethodImpl(Inline)]
            public FieldType(FieldDataKind dk)
            {
                Data = (byte)((byte)dk | ((byte)dk << 3));
            }

            [MethodImpl(Inline)]
            public FieldType(FieldDataKind dk, FieldDomainType dt)
            {
                var a = (uint)dk;
                var b = (uint)dt;
                if(b > LastKind)
                    b <<= 3;
                Data = (byte)(a | b);
            }

            public FieldDataKind DataKind
            {
                [MethodImpl(Inline)]
                get => (FieldDataKind)(Data & 0b111);
            }

            public FieldDomainType DomainType
            {
                [MethodImpl(Inline)]
                get => (FieldDomainType)(Data >> 3);
            }

            public static FieldType Empty => default;
        }
    }
}