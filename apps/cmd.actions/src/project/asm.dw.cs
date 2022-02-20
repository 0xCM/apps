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
            var src = ObjDump.LoadRows(WsProjects.Table<ObjDumpRow>(project));
            using var map = AsmCodeMap.create(Wf);
            map.Include(project,src);
            map.Seal();
            var entries = map.Entries;
            TableEmit(entries, AsmCodeMapEntry.RenderWidths, WsProjects.Table<AsmCodeMapEntry>(project));
            return true;
        }


    }
}