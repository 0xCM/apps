//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;


    partial class ProjectCmdProvider
    {
        [CmdOp("asm/dw")]
        Outcome AsmDw(CmdArgs args)
        {
            var project = Project();
            var src = ObjDump.LoadRows(ProjectDb.ProjectTable<ObjDumpRow>(project));
            using var dispenser = Alloc.asm();
            var blocks = AsmObjects.DistillBlocks(src, dispenser);
            return true;
        }

    }
}