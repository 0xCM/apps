//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/flows")]
        Outcome ProjectFlows(CmdArgs args)
        {
            var project = Project();
            var context = WsContext.load(project);
            var index = context.Flows;
            var kinds = array(FileKind.ObjAsm, FileKind.XedRawDisasm, FileKind.McAsm, FileKind.Sym);
            var buffer = list<FileRef>();

            foreach(var kind in kinds)
            {
                var targets = index.Files(kind);
                foreach(var target in targets)
                {
                    if(index.Root(target.Path, out var source))
                    {
                        var fmt = string.Format("<{0}:{1}, {2}:{3}>", target.Path.FileName, target.Kind, source.Path.FileName, source.Kind);
                        Write(fmt);
                    }
                }
            }

            return true;
        }
    }
}