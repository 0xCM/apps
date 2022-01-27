//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("runtime/memory")]
        Outcome MapMemory(CmdArgs args)
        {
            var dst = ProjectDb.LogTable<ProcessMemoryRegion>();
            TableEmit(ImageMemory.regions().View, dst);
            return true;
        }
    }
}