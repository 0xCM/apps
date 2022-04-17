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

            public readonly FieldSize Size;

            public readonly FieldTypeName Type;

            public readonly FieldTypeName EffectiveType;

            [MethodImpl(Inline)]
            public FieldSpec(FieldKind kind, FieldSize sz, FieldTypeName type, FieldTypeName eff)
            {
                Kind = kind;
                Size = sz;
                Type = type;
                EffectiveType = eff;
            }

            public static FieldSpec Empty => default;
        }
    }
}