//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("project/mcasm")]
        Outcome McAsmDocs(CmdArgs args)
        {
            var project = Project();
            var catalog = FileCatalog.load(project);
            var files = catalog.Entries(FileKind.McAsm);
            var docs = ProjectSvc.CalcMcAsmDocs(project);
            var count = docs.Count;
            for(var i=0; i<count; i++)
                MergeDirectives(docs[i]);

            return true;
        }
    }
}