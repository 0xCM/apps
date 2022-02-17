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
            EmitAsmCodeBlocks(project);
            return true;
        }

        public void EmitAsmCodeBlocks(IProjectWs project)
        {
            var src = ObjDump.LoadRows(ProjectDb.ProjectTable<ObjDumpRow>(project));
            using var dispenser = Alloc.asm();
            var lookup = CodeBanks.DistillBlocks(src, dispenser, project.Name);
        }
    }
}