//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/context")]
        void EmitProjectContext()
        {
             var context = Context();
             var project = context.Project;
             Write(string.Format("{0,-18}:{1}", "Project", project.Id));
             iter(project.OutFiles(FileKind.Obj), file => Write(file));
        }

        [CmdOp("project/asm/map")]
        void CreateCodeMap()
        {
            using var dst = Alloc.create();
            var src = Project();
            var map = MapAsmCode(src, dst);
            var count = map.EntryCount;
            for(var i=0; i<count; i++)
            {

            }
        }

        AsmCodeMap MapAsmCode(IWsProject src, Alloc dst)
            => AsmObjects.MapAsm(src, dst);
    }
};