//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        FS.FolderPath GetToolOut(ToolId tool)
            => Ws.Output().Subdir(tool.Format());
    }
}