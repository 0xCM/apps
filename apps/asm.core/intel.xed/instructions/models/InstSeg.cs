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
        public readonly struct InstSeg : IEquatable<InstSeg>, IComparable<InstSeg>
        {
            public readonly FieldKind Field;

            public readonly InstSegType Type;

            readonly ByteBlock3 Pad;

            [MethodImpl(Inline)]
            internal InstSeg(FieldKind field, BitNumber<byte> src)
            {
                Field = field;
                Type = InstSegTypes.type(src.Width, src.Value);
                Pad = default;
                core.@as<BitNumber<byte>>(Pad.First) = src;
            }

            [MethodImpl(Inline)]
            internal InstSeg(FieldKind field, InstSegType type)
            {
                Field = field;
                Type = type;
                Pad = default;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => Type.IsSymbolic;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Type.IsLiteral;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public BitNumber<byte> _ToLiteral()
                => core.@as<BitNumber<byte>>(Pad.First);

            public byte ToLiteral()
            {
                if(Type.IsLiteral)
                    return Type.LiteralValue();
                else
                    return uint5.Max;
            }

            public int CompareTo(InstSeg src)
            {
                var result = XedRules.cmp(Field,src.Field);
                if(result == 0)
                {
                    if(IsLiteral && src.IsLiteral)
                        result = ToLiteral().CompareTo(src.ToLiteral());
                    else if(!IsLiteral && !src.IsLiteral)
                        result = Type.Id.CompareTo(src.Type.Id);
                    else if(IsLiteral && !src.IsLiteral)
                        result = -1;
                    else
                        result = 1;
                }
                return result;
            }

            [MethodImpl(Inline)]
            public bool Equals(InstSeg src)
                => Field == src.Field && Type == src.Type;

            public override int GetHashCode()
                => (int)alg.hash.combine(Type.GetHashCode(),(uint)Field);

            public override bool Equals(object src)
                => src is InstSeg s && Equals(s);

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0}[{1}]", XedRender.format(Field), Type.Format());

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(InstSeg a, InstSeg b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(InstSeg a, InstSeg b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static explicit operator ulong(InstSeg src)
                => core.@as<InstSeg,ulong>(src);

            [MethodImpl(Inline)]
            public static explicit operator InstSeg(ulong src)
                => core.@as<ulong,InstSeg>(src);

            public static InstSeg Empty => default;
        }
    }
}