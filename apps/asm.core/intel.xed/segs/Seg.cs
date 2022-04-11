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
        public readonly struct Seg : IEquatable<Seg>, IComparable<Seg>
        {
            public readonly FieldKind Field;

            public readonly asci8 Value;

            [MethodImpl(Inline)]
            internal Seg(FieldKind field, asci8 value)
            {
                Field = field;
                Value = value;
            }

            [MethodImpl(Inline)]
            internal Seg(FieldKind field, byte width, asci8 value)
            {
                Field = field;
                Value = value;
            }

            public bool IsSymbolic
            {
                [MethodImpl(Inline)]
                get => !bits(Value);
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => bits(Value);
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

            public int CompareTo(Seg src)
            {
                var result = XedRules.cmp(Field,src.Field);
                if(result == 0)
                {
                    if(IsLiteral && src.IsLiteral)
                        result = Value.CompareTo(src.Value);
                    else if(!IsLiteral && !src.IsLiteral)
                        result = Value.CompareTo(src.Value);
                    else if(IsLiteral && !src.IsLiteral)
                        result = -1;
                    else
                        result = 1;
                }
                return result;
            }

            [MethodImpl(Inline)]
            public bool Equals(Seg src)
                => Field == src.Field && Value == src.Value;

            public override int GetHashCode()
                => (int)alg.hash.combine(Value.GetHashCode(),(uint)Field);

            public override bool Equals(object src)
                => src is Seg s && Equals(s);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static bool operator ==(Seg a, Seg b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(Seg a, Seg b)
                => !a.Equals(b);

            public static Seg Empty => default;
        }
    }
}