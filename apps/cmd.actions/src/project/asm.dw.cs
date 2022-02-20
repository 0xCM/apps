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
            using var dispensers = Alloc.allocate();
            var project = Project();
            var src = ObjDump.LoadRows(WsProjects.Table<ObjDumpRow>(project));
            var entries = AsmObjects.MapCode(project, src, dispensers);
            TableEmit(entries.View, AsmCodeMapEntry.RenderWidths, WsProjects.Table<AsmCodeMapEntry>(project));
            return true;
        }
    }
}