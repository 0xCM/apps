//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct DisasmOpDetail
        {
            public DisasmOpInfo OpInfo;

            public OpWidthInfo OpWidth;

            public OpName OpName;

            public DisasmOp Def;

            public @string RuleDescription;

            public TextBlock DefDescription;

            public byte Index
            {
                [MethodImpl(Inline)]
                get => OpInfo.Index;
            }

            public OpAction Action
            {
                [MethodImpl(Inline)]
                get => OpInfo.Action;
            }

            public string Format()
                => DefDescription;

            public override string ToString()
                => Format();
        }
    }
}