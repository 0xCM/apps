//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(Width, 8)]
        public readonly struct ModIndicator : IComparable<ModIndicator>, IEquatable<ModIndicator>
        {
            public const byte Width = uint3.Width;

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

            [MethodImpl(Inline)]
            public static explicit operator ModIndicator(uint3 src)
                => new ModIndicator((ModKind)(byte)src);

            [MethodImpl(Inline)]
            public static explicit operator uint3(ModIndicator src)
                => (uint3)(byte)src.Kind;

            public static ModIndicator Empty => default;
        }
    }
}