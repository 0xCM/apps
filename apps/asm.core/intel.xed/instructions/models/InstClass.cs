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
        public readonly struct InstClass
        {
            public readonly IClass Kind;

            [MethodImpl(Inline)]
            public InstClass(IClass mode)
            {
                Kind = mode;
            }

            public readonly string Classifier
                => XedPatterns.classifier(this);

            public Identifier Name
                => Kind.ToString();

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
                => Classifier.CompareTo(src.Classifier);

            [MethodImpl(Inline)]
            public bool Equals(InstClass src)
                => Kind == src.Kind;

            public override int GetHashCode()
                => (int)Kind;

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
            public static explicit operator InstClass(ushort src)
                =>new InstClass((IClass)src);

           public static InstClass Empty => default;
        }
    }
}