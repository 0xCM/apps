//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class AsmEventReceiver
    {
        FileCatalog Files;

        Index<AsmSyntaxRow> SyntaxRows;

        Index<AsmInstructionRow> InstructionRows;

        Index<XedDisasmDetail> XedRows;

        Index<ObjDumpRow> ObjDumpRows;

        CoffSymIndex CoffSymbols;

        Index<ObjBlock> ObjBlocks;

        public AsmEventReceiver()
        {
            CoffSymbols = CoffSymIndex.Empty;
            ObjBlocks = sys.empty<ObjBlock>();
        }

        public AsmDataCollection Emit()
            => new AsmDataCollection(Files, SyntaxRows, InstructionRows, XedRows, ObjDumpRows, CoffSymbols, ObjBlocks);


        public virtual void Initialized(WsContext context)
        {
            Files = context.Files;
        }

        public virtual void Collected(Index<ObjDumpRow> src)
        {
            ObjDumpRows = src;

        }

        public virtual void Collected(Index<ObjBlock> src)
        {
            ObjBlocks = src;
        }

        public virtual void Collected(Index<ObjSymRow> src)
        {

        }

        public virtual void Collected(CoffSymIndex src)
        {
            CoffSymbols = src;
        }

        public virtual void Collected(Index<AsmSyntaxRow> src)
        {
            SyntaxRows = src;
        }

        public virtual void Collected(Index<AsmInstructionRow> src)
        {
            InstructionRows = src;
        }

        public virtual void Collected(Index<XedDisasmDetail> src)
        {
            XedRows = src;
        }
    }
}