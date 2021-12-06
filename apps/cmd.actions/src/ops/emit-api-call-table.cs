//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("emit-api-call-table")]
        protected Outcome EmitCallTable(CmdArgs args)
        {
            Wf.AsmCallPipe().EmitRows(Wf.AsmDecoder().Decode(Blocks()));
            return true;
        }
    }
}