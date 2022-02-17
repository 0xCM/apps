//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

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
            var blocks = CodeBanks.DistillBlocks(src);
        }

    }
}