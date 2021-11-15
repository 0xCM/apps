//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".tool-out-dir", "Displays the path of a tool output directory")]
        Outcome ToolOut(CmdArgs args)
        {
            var result = GetToolOut(args, out var dir);
            if(result)
                Write(dir);
            return result;
        }
    }
}