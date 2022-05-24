//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("runtime/memory")]
        Outcome MapMemory(CmdArgs args)
        {
            var dst = ProjectDb.LogTable<ProcessMemoryRegion>();
            AppSvc.TableEmit(ImageMemory.regions().View, dst);
            return true;
        }
    }
}