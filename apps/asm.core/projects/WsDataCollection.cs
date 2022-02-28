//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class WsDataCollection
    {
        public readonly FileCatalog Files;

        public readonly IProjectWs Project;

        public readonly CoffSymIndex CoffSymbols;

        public readonly Index<ObjBlock> ObjBlocks;

        public readonly Index<AsmInstructionRow> InstructionRows;

        public readonly Index<AsmSyntaxRow> SyntaxRows;

        public readonly Index<AsmDisasmDetail> XedRows;

        public readonly Index<ObjDumpRow> ObjDumpRows;

        internal WsDataCollection(
            IProjectWs project,
            FileCatalog files,
            Index<AsmSyntaxRow> syntax,
            Index<AsmInstructionRow> inst,
            Index<AsmDisasmDetail> xed,
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

        ConstLookup<InstructionId,AsmDisasmDetail> _DetailLookup;

        object locker;

        public ConstLookup<InstructionId,AsmDisasmDetail> DetailLookup
        {
            get
            {
                lock(locker)
                {
                    if(_DetailLookup == null)
                        _DetailLookup = XedRows.Storage.Map(x => (x.InstructionId, x)).ToConstLookup();
                }
                return _DetailLookup;
            }
        }
    }
}