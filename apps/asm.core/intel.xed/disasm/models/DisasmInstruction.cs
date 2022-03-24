//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1), Record(TableId)]
        public struct DisasmInstruction
        {
            public const string TableId = "xed.disasm.instruction";

            public InstClass InstClass;

            public InstForm InstForm;

            public Index<Facet<string>> Props;
        }
    }
}