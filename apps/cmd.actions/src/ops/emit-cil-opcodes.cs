//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("emit-cil-opcodes")]
        protected Outcome EmitCilOpCodes(CmdArgs args)
        {
            var dst = Db.IndexTable<CilOpCode>();
            TableEmit(Cil.opcodes(), dst);
            return true;
        }
    }
}