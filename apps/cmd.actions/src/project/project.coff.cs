//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
       [CmdOp("project/coff")]
        Outcome Blah(CmdArgs args)
        {
            var project = Project();
            var symindex = CoffServices.LoadSymIndex(project);
            var catalog = project.FileCatalog();
            var blocks = ProjectData.LoadObjBlocks(project);
            var files = catalog.Entries(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var docsyms = symindex.Symbols();
            iter(blocks, block => Write(string.Format("'{0}'", block.BlockName)));
            return true;
        }
    }
}