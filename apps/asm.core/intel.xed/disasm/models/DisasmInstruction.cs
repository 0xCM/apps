//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1), Record(TableId)]
        public struct DisasmInstruction
        {
            public const string TableId = "xed.disasm.instruction";

            public IClass Class;

            public IFormType Form;

            public Index<Facet<string>> Props;
        }
    }
}