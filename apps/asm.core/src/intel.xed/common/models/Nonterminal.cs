//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct Nonterminal : IEquatable<Nonterminal>, IComparable<Nonterminal>
        {
            readonly GroupName EncodingGroup;

            readonly NontermKind NontermKind;

            public Nonterminal(NontermKind kind)
            {
                NontermKind = kind;
                EncodingGroup = 0;
            }

            public Nonterminal(GroupName name)
            {
                NontermKind = 0;
                EncodingGroup = name;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => EncodingGroup == 0 && NontermKind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public string Name
                => EncodingGroup == 0 ? XedRender.format(NontermKind) : XedRender.format(EncodingGroup);

            [MethodImpl(Inline)]
            public bool Equals(Nonterminal src)
                => EncodingGroup == src.EncodingGroup && NontermKind == src.NontermKind;

            public override bool Equals(object src)
                => src is Nonterminal x && Equals(x);

            public override int GetHashCode()
                => (int)(uint)this;

            public int CompareTo(Nonterminal src)
                => Name.CompareTo(src.Name);

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(NontermKind src)
                => new Nonterminal(src);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(GroupName src)
                => new Nonterminal(src);

            public static explicit operator uint(Nonterminal src)
                => core.@as<Nonterminal,uint>(src);

            public static Nonterminal Empty => default;
        }
    }
}