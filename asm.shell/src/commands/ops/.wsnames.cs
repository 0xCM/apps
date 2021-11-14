//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".wsnames")]
        Outcome Workspaces(CmdArgs args)
        {
            iter(typeof(WsNames).LiteralFields(), f => Write(f.GetRawConstantValue()));
            return true;
        }
    }
}