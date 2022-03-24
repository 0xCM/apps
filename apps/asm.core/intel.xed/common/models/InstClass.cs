//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedPatterns
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
                => classifier(this);

            public bool Locked
            {
                [MethodImpl(Inline)]
                get => locked(Kind);
            }

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
            public static implicit operator InstClass(IClass src)
                => new InstClass(src);

            [MethodImpl(Inline)]
            public static implicit operator IClass(InstClass src)
                => src.Kind;

            public static InstClass Empty => default;
        }
    }
}