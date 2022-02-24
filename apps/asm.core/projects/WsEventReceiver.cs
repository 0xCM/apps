//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class WsEventReceiver
    {
        FileCatalog Files;

        public WsEventReceiver()
        {

        }

        public virtual void Initialized(WsContext context)
        {
            Files = context.Files;
        }

        public virtual void Collected(Index<ObjDumpRow> src)
        {

        }

        public virtual void Collected(Index<ObjBlock> src)
        {

        }

        public virtual void Collected(Index<ObjSymRow> src)
        {

        }

        public virtual void Collected(CoffSymIndex src)
        {

        }

        public virtual void Collected(Index<AsmSyntaxRow> src)
        {

        }

        public virtual void Collected(ConstLookup<FS.FilePath,Index<AsmEncodingRow>> src)
        {

        }

        public virtual void Collected(Index<AsmInstructionRow> src)
        {

        }

        public virtual void Collected(Index<XedDisasmDetail> src)
        {

        }
    }
}