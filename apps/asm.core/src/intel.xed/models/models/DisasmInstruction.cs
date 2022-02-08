//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;

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