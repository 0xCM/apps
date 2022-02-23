//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public class WsEventReceiver
    {
        FileCatalog Files;

        public FileCatalog FileCatalog
            => Files;

        public WsEventReceiver()
        {
            Files = FileCatalog.create();
        }

        public virtual void Initialized(WsContext collect)
        {
            Files = collect.Files;
        }

        public virtual void Collected(in FileRef src, in ObjDumpRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmInstructionRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmSyntaxRow row)
        {

        }

        public virtual void Collected(in FileRef src, in AsmEncodingRow row)
        {

        }
    }
}