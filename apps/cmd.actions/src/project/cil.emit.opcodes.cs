//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("cil/emit/opcodes")]
        Outcome EmitCilOpCodes(CmdArgs args)
        {
            var dst = ProjectDb.ApiTablePath<CilOpCode>();
            TableEmit(Cil.opcodes(), dst);
            return true;
        }
    }
}