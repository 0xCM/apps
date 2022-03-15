//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct Nonterminal : IEquatable<Nonterminal>, IComparable<Nonterminal>
        {
            const ushort LoMask = 0b01111111_11111111;

            readonly ushort Data;

            public Nonterminal(NontermKind kind)
            {
                Data = bit.set((ushort)kind, 15, XedParsers.parse(XedRender.format(kind), out GroupName _));
            }

            [MethodImpl(Inline)]
            public Nonterminal(GroupName kind)
            {
                Data = bit.enable((ushort)kind,15);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data != 0;
            }

            public bool IsGroup
            {
                [MethodImpl(Inline)]
                get => bit.test(Data,15);
            }

            public string Name
                => IsGroup
                ? XedRender.format((GroupName)(Data & LoMask))
                : XedRender.format((NontermKind)(Data & LoMask));

            [MethodImpl(Inline)]
            public bool Equals(Nonterminal src)
                => Data == src.Data;

            public override bool Equals(object src)
                => src is Nonterminal x && Equals(x);

            public override int GetHashCode()
                => Data;

            public int CompareTo(Nonterminal src)
                => Name.CompareTo(src.Name);

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(NontermKind src)
                => new Nonterminal(src);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(GroupName src)
                => new Nonterminal(src);

            [MethodImpl(Inline)]
            public static explicit operator ushort(Nonterminal src)
                => src.Data;

            public static Nonterminal Empty => default;
        }
    }
}