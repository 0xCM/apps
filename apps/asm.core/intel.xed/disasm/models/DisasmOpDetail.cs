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
        public struct DisasmOpDetail
        {
            public byte Index;

            public InstOpClass OpClass;

            public OpWidthInfo OpWidth;

            public OpName OpName;

            public DisasmOp Def;

            public @string RuleDescription;

            public TextBlock DefDescription;

            public OpAction Action
            {
                [MethodImpl(Inline)]
                get => OpClass.Action;
            }

            public string Format()
                => DefDescription;

            public override string ToString()
                => Format();
        }
    }
}