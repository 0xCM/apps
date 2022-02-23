//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/dw")]
        Outcome AsmDw(CmdArgs args)
        {
            using var dispensers = Alloc.allocate();
            var project = Project();
            var src = ObjDump.LoadRows(project);
            var index = LlvmMc.LoadAsmIndex(project);
            var entries = AsmObjects.MapCode(project, index, src, dispensers);
            TableEmit(entries.View, AsmCodeMapEntry.RenderWidths, Projects.Table<AsmCodeMapEntry>(project));
            return true;
        }
    }
}