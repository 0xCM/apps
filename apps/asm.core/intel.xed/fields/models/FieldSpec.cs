//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct FieldSpec
        {
            public readonly FieldKind Kind;

            public readonly FieldType Type;

            public readonly FieldType EffectiveType;

            public readonly byte Width;

            public readonly byte EffectiveWidth;

            [MethodImpl(Inline)]
            public FieldSpec(FieldKind kind, FieldType type, FieldType eff, byte width, byte ewidth)
            {
                Kind = kind;
                Type = type;
                EffectiveType = eff;
                Width = width;
                EffectiveWidth = ewidth;
            }

            public static FieldSpec Empty => default;
        }
    }
}