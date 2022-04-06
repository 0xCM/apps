//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(32)]
        public readonly struct Nonterminal : IEquatable<Nonterminal>, IComparable<Nonterminal>
        {
            public readonly NontermKind Kind;

            public Nonterminal(NontermKind kind)
            {
                Kind = kind;
            }

            public string Name
                => XedRender.name(this);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            [MethodImpl(Inline)]
            public bool Equals(Nonterminal src)
                => Kind == src.Kind;

            public override bool Equals(object src)
                => src is Nonterminal x && Equals(x);

            public override int GetHashCode()
                => (int)(uint)this;

            public int CompareTo(Nonterminal src)
                => Format().CompareTo(src.Format());

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0}()", XedRender.format(Kind));

            public override string ToString()
                => Format();

            public static explicit operator ushort(Nonterminal src)
                => (ushort)src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator NontermKind(Nonterminal src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(NontermKind src)
                => new Nonterminal(src);

            public static Nonterminal Empty => default;
        }
    }
}