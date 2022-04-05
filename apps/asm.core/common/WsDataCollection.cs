//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedRules;
    using static XedDisasm;

    public class WsDataCollection
    {
        public readonly FileCatalog Files;

        public readonly IProjectWs Project;

        public readonly CoffSymIndex CoffSymbols;

        public readonly Index<ObjBlock> ObjBlocks;

        public readonly Index<AsmInstructionRow> InstructionRows;

        public readonly Index<AsmSyntaxRow> SyntaxRows;

        public readonly ConstLookup<FileRef,Index<DisasmDetail>> XedRows;

        public readonly Index<ObjDumpRow> ObjDumpRows;

        internal WsDataCollection(
            IProjectWs project,
            FileCatalog files,
            Index<AsmSyntaxRow> syntax,
            Index<AsmInstructionRow> inst,
            ConstLookup<FileRef,Index<DisasmDetail>> xed,
            Index<ObjDumpRow> objdump,
            CoffSymIndex coffsym,
            ObjBlock[] objblocks
            )
        {
            Project = project;
            Files = files;
            SyntaxRows = syntax;
            InstructionRows = inst;
            XedRows = xed;
            ObjDumpRows = objdump;
            CoffSymbols = coffsym;
            ObjBlocks = objblocks;
            locker = new();
        }

        object locker;

    }
}