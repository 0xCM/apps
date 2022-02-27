//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmDataCollection
    {
        public readonly FileCatalog Files;

        public readonly IProjectWs Project;

        public readonly CoffSymIndex CoffSymbols;

        public readonly Index<ObjBlock> ObjBlocks;

        public readonly Index<AsmInstructionRow> InstructionRows;

        public readonly Index<AsmSyntaxRow> SyntaxRows;

        public readonly Index<XedDisasmDetail> XedRows;

        public readonly Index<ObjDumpRow> ObjDumpRows;

        internal AsmDataCollection(
            IProjectWs project,
            FileCatalog files,
            Index<AsmSyntaxRow> syntax,
            Index<AsmInstructionRow> inst,
            Index<XedDisasmDetail> xed,
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

        ConstLookup<InstructionId,XedDisasmDetail> _XedLookup;

        object locker;

        public ConstLookup<InstructionId,XedDisasmDetail> XedLookup
        {
            get
            {
                lock(locker)
                {
                    if(_XedLookup == null)
                        _XedLookup = XedRows.Storage.Map(x => (x.InstructionId, x)).ToConstLookup();
                }
                return _XedLookup;
            }
        }
    }
}