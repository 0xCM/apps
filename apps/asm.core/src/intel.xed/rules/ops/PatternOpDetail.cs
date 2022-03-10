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
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct PatternOpDetail
        {
            public const byte FieldCount = 13;

            public uint Pattern;

            public IClass Mnemonic;

            public byte OpIndex;

            public RuleOpName Name;

            public RuleOpKind Kind;

            public @string Expression;

            public RuleOpAttrib Action;

            public RuleOpAttrib Width;

            public RuleOpAttrib EType;

            public RuleOpAttrib EncGroup;

            public RuleOpAttrib RegLit;

            public RuleOpAttrib Modifier;

            public RuleOpAttrib Visibility;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,8,8,8,32,8,10,8,16,12,8,1};

            public static PatternOpDetail Empty => default;
        }
    }
}