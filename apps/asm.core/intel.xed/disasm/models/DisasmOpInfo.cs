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
        public struct DisasmOpInfo
        {
            public byte Index;

            public FieldKind Kind;

            public OpAction Action;

            public Visibility Visiblity;

            public OpWidthCode WidthCode;

            public OpType OpType;

            public asci16 Selector;
        }
    }
}