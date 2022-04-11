//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct ModKind : IComparable<ModKind>, IEquatable<ModKind>
        {
            readonly ModIndicator Indicator;

            [MethodImpl(Inline)]
            public ModKind(ModIndicator indicator)
            {
                Indicator = indicator;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Indicator == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Indicator != 0;
            }

            public string Format()
                => XedRender.format(Indicator);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(ModKind src)
                => ((byte)Indicator).CompareTo((byte)src.Indicator);

            [MethodImpl(Inline)]
            public bool Equals(ModKind src)
                => Indicator == src.Indicator;

            [MethodImpl(Inline)]
            public static implicit operator ModKind(ModIndicator src)
                => new ModKind(src);

            public static ModKind Empty => default;
        }
    }
}