//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("project/flows")]
        void ProjectFlows()
        {
            // var index = Projects.LoadBuildFlowIndex(Context().Project);
            // var kinds = array(FileKind.ObjAsm, FileKind.XedRawDisasm, FileKind.McAsm, FileKind.Sym);
            // var buffer = list<FileRef>();
            // foreach(var kind in kinds)
            // {
            //     var targets = index.Files(kind);
            //     foreach(var target in targets)
            //     {
            //         if(index.Root(target.Path, out var source))
            //         {
            //             var fmt = string.Format("<{0}:{1}, {2}:{3}>", target.Path.FileName, target.Kind, source.Path.FileName, source.Kind);
            //             Write(fmt);
            //         }
            //     }
            // }
        }

        [CmdOp("project/files")]
        void ProjectFiles()
        {
            //var project = LoadProject("canonical");

            //iter(project.Files(), file => Write(file));

            //var context = Context();
            //var files = FileCatalog.load(context.Project).Entries(FileKind.Obj, FileKind.O);

            //var catalog = Projects.Catalog(Project());
            //iter(catalog.Entries(), file => Write(file));
        }
    }
}