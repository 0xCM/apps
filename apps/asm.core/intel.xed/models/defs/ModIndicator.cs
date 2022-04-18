//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ModIndicator : IComparable<ModIndicator>, IEquatable<ModIndicator>
        {
            public readonly ModKind Kind;

            [MethodImpl(Inline)]
            public ModIndicator(ModKind kind)
            {
                Kind = kind;
            }

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

            public bool IsNonZero
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => XedRender.format(Kind);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(ModIndicator src)
                => ((byte)Kind).CompareTo((byte)src.Kind);

            [MethodImpl(Inline)]
            public bool Equals(ModIndicator src)
                => Kind == src.Kind;

            [MethodImpl(Inline)]
            public static implicit operator ModIndicator(ModKind src)
                => new ModIndicator(src);

            public static ModIndicator Empty => default;
        }
    }
}