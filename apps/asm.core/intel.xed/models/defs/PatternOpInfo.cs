//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;


    partial class XedPatterns
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct PatternOpInfo
        {
            public byte Index;

            public OpNameKind Name;

            public OpKind Kind;

            public OpAction Action;

            public OpWidthCode WidthCode;

            public GprWidth GprWidth;

            public ElementType CellType;

            public ushort BitWidth;

            public ushort CellWidth;

            public Register RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerminal;

            public bit IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => NonTerminal.IsNonEmpty;
            }

            public static PatternOpInfo Empty => default;
        }
    }
}