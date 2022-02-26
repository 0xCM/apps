//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmDataCollection
    {
        public readonly FileCatalog Files;

        public readonly CoffSymIndex CoffSymbols;

        public readonly Index<ObjBlock> ObjBlocks;

        public readonly Index<AsmInstructionRow> InstructionRows;

        public readonly Index<AsmSyntaxRow> SyntaxRows;

        public readonly Index<XedDisasmDetail> XedRows;

        public readonly Index<ObjDumpRow> ObjDumpRows;

        internal AsmDataCollection(FileCatalog files,
            Index<AsmSyntaxRow> syntax,
            Index<AsmInstructionRow> inst,
            Index<XedDisasmDetail> xed,
            Index<ObjDumpRow> objdump,
            CoffSymIndex coffsym,
            ObjBlock[] objblocks
            )
        {
            Files = files;
            SyntaxRows = syntax;
            InstructionRows = inst;
            XedRows = xed;
            ObjDumpRows = objdump;
            CoffSymbols = coffsym;
            ObjBlocks = objblocks;
        }

        // public bool Encoding(InstructionId id, out AsmEncodingRow dst)
        // {
        //     if(EncodingLookup.Find(id, out dst))
        //         return true;
        //     dst = AsmEncodingRow.Empty;
        //     return false;
        // }

        // public bool Encoding(AsmRowKey key, out AsmEncodingRow dst)
        // {
        //     if(EncodingKeys.TryGetValue(key, out var id))
        //     if(EncodingLookup.Find(id, out dst))
        //         return true;
        //     dst = AsmEncodingRow.Empty;
        //     return false;
        // }

        // public bool Syntax(AsmRowKey key, out AsmSyntaxRow dst)
        // {
        //     if(SyntaxLookup.Find(key, out dst))
        //         return true;
        //     dst = AsmSyntaxRow.Empty;
        //     return false;
        // }

        // public bool Instruction(AsmRowKey key, out AsmInstructionRow dst)
        // {
        //     if(InstructionLookup.Find(key, out dst))
        //         return true;
        //     dst = AsmInstructionRow.Empty;
        //     return false;
        // }

        // public bool ObjDump(InstructionId id, out ObjDumpRow dst)
        // {
        //     if(ObjDumpLookup.Find(id, out dst))
        //         return true;
        //     dst = ObjDumpRow.Empty();
        //     return false;
        // }

    }
}