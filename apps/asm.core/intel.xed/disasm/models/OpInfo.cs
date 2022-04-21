//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct OpInfo
        {
            public byte Index;

            public OpKind Kind;

            public OpName Name;

            public OpAction Action;

            public Visibility Visibility;

            public OpWidthCode WidthCode;

            public OpType OpType;

            public Nonterminal Selector;

            public asci16 SelectorName;
        }
    }
}