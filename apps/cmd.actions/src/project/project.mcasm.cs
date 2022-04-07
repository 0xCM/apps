//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("project/mcasm")]
        Outcome McAsmDocs(CmdArgs args)
        {
            var project = Project();
            var catalog = project.FileCatalog();
            var files = catalog.Entries(FileKind.McAsm);

            var docs = ProjectData.CalcMcAsmDocs(project);
            var count = docs.Count;
            for(var i=0; i<count; i++)
                MergeDirectives(docs[i]);

            return true;
        }
    }
}