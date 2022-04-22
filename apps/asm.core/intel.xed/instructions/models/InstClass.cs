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
        [DataWidth(Width,16)]
        public readonly struct InstClass : IComparable<InstClass>, IEquatable<InstClass>
        {
            public const byte Width = Hex12.Width;

            public readonly IClass Kind;

            public InstClass(IClass kind)
            {
                Require.nonzero(kind);
                Kind = kind;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => (uint)Kind;
            }

            public readonly InstClass Classifier
                => this;//IsEmpty ? Empty : XedPatterns.normalize(this);

            public Identifier Name
                => IsEmpty ? EmptyString : Kind.ToString(); //IsEmpty ? EmptyString : Kind.ToString();

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

            public int CompareTo(InstClass src)
                => Classifier.Format().CompareTo(src.Classifier.Format());

            [MethodImpl(Inline)]
            public bool Equals(InstClass src)
                => Kind == src.Kind;

            public override int GetHashCode()
                => Hash;

            public override bool Equals(object o)
                => o is InstClass c && Equals(c);

            [MethodImpl(Inline)]
            public static implicit operator InstClass(IClass src)
                => new InstClass(src);

            [MethodImpl(Inline)]
            public static implicit operator IClass(InstClass src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static bool operator ==(InstClass a, InstClass b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(InstClass a, InstClass b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static explicit operator ushort(InstClass src)
                => (ushort)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator Hex12(InstClass src)
                => (ushort)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator InstClass(ushort src)
                =>new InstClass((IClass)src);

           public static InstClass Empty => default;
        }
    }
}