//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedRules;
    using static XedDisasm;

    public class WsEventReceiver
    {
        IProjectWs Project;

        FileCatalog Files;

        Index<AsmSyntaxRow> SyntaxRows;

        Index<AsmInstructionRow> InstructionRows;

        Index<DisasmDetail> XedRows;

        Index<ObjDumpRow> ObjDumpRows;

        CoffSymIndex CoffSymbols;

        Index<ObjBlock> ObjBlocks;

        public WsEventReceiver()
        {
            CoffSymbols = CoffSymIndex.Empty;
            ObjBlocks = sys.empty<ObjBlock>();
        }

        public WsDataCollection Emit()
            => new WsDataCollection(Project, Files, SyntaxRows, InstructionRows, XedRows, ObjDumpRows, CoffSymbols, ObjBlocks);


        public virtual void Initialized(WsContext context)
        {
            Files = context.Catalog;
            Project = context.Project;
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

        public virtual void Collected(Index<DisasmDetail> src)
        {
            XedRows = src;
        }
    }
}