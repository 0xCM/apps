//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [DataWidth(16)]
        public readonly struct InstIsa : IComparable<InstIsa>, IEquatable<InstIsa>
        {
            public readonly IsaKind Kind;

            [MethodImpl(Inline)]
            public InstIsa(IsaKind mode)
            {
                Kind = mode;
            }

            public Identifier Name
                => XedRender.format(Kind);

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

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public int CompareTo(InstIsa src)
                => Name.CompareTo(src.Name);

            [MethodImpl(Inline)]
            public bool Equals(InstIsa src)
                => Kind == src.Kind;

            public override int GetHashCode()
                => (int)Kind;

            public override bool Equals(object o)
                => o is InstIsa c && Equals(c);

            [MethodImpl(Inline)]
            public static implicit operator InstIsa(IsaKind src)
                => new InstIsa(src);

            [MethodImpl(Inline)]
            public static implicit operator IsaKind(InstIsa src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static bool operator ==(InstIsa a, InstIsa b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(InstIsa a, InstIsa b)
                => !a.Equals(b);

            public static InstIsa Empty => default;
        }
    }
}