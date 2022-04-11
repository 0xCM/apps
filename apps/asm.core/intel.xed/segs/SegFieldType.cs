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
        public readonly struct SegFieldType : IEquatable<SegFieldType>
        {
            public readonly byte Id;

            readonly byte N;

            readonly byte Literal;

            readonly byte Pad;

            [MethodImpl(Inline)]
            public SegFieldType(byte id)
            {
                Id = id;
                Literal = 0;
                N = 0;
                Pad = 0;
            }

            [MethodImpl(Inline)]
            public SegFieldType(uint value)
            {
                Id = (byte)(value & 0xFF);
                Pad = 0;
                if(Id != 0)
                {
                    N = (byte)((value >> 8) & 0xFF);
                    Literal = (byte)((value >> 16) & 0xFF);
                }
                else
                {
                    N = 0;
                    Literal = 0;
                }
            }

            [MethodImpl(Inline)]
            internal SegFieldType(byte n, byte literal)
            {
                Id = 0;
                N = n;
                Literal = literal;
                Pad = 0;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => N == 0 && Id !=0;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => N != 0 & Id == 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == 0 && N == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            [MethodImpl(Inline)]
            public byte LiteralValue()
                => Literal;

            public string Format()
            {
                var dst = EmptyString;
                if(IsLiteral)
                {
                    switch(N)
                    {
                        case 1:
                            dst = XedRender.format((uint1)Literal);
                        break;
                        case 2:
                            dst = XedRender.format((uint2)Literal);
                        break;
                        case 3:
                            dst = XedRender.format((uint3)Literal);
                        break;
                        case 4:
                            dst = XedRender.format((uint4)Literal);
                        break;
                    }
                }
                else
                {
                    dst = SegTypes.pattern(this);
                }

                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(SegFieldType src)
                => (uint)this == (uint)src;

            public override int GetHashCode()
                => (int)(uint)this;

            public override bool Equals(object src)
                => src is SegFieldType x && Equals(x);

            [MethodImpl(Inline)]
            public static explicit operator uint(SegFieldType src)
                => src.Id;

            [MethodImpl(Inline)]
            public static explicit operator SegFieldType(uint src)
                => new SegFieldType(src);

            [MethodImpl(Inline)]
            public static bool operator ==(SegFieldType a, SegFieldType b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(SegFieldType a, SegFieldType b)
                => !a.Equals(b);

            public static SegFieldType Empty => default;
        }
    }
}