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
        [DataWidth(Width)]
        public readonly struct InstClass : IComparable<InstClass>, IEquatable<InstClass>
        {
            public static InstClass parse(string src, out bool result)
            {
                result = XedParsers.parse(src, out InstClass dst);
                return dst;
            }

            public const byte Width = num11.Width;

            public readonly InstClassType Kind;

            public InstClass(InstClassType kind)
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
                => this;

            public Identifier Name
                => IsEmpty ? EmptyString : Kind.ToString();

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
            public static implicit operator InstClass(InstClassType src)
                => new InstClass(src);

            [MethodImpl(Inline)]
            public static implicit operator InstClassType(InstClass src)
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
                => new InstClass((InstClassType)src);

           public static InstClass Empty => default;
        }
    }
}