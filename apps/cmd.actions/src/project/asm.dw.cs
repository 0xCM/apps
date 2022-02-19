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
            map.Include(src);
            map.Seal();
            var entries = map.Entries;
            TableEmit(entries, AsmCodeMapEntry.RenderWidths, WsProjects.Table<AsmCodeMapEntry>(project));
            return true;
        }


        class AsmTraverser : AsmCodeBlockTraverser
        {
            Receiver<Label,AsmCodeBlock> BlockReceiver;

            Label BlockOrigin;

            public AsmTraverser(Receiver<Label,AsmCodeBlock> receiver)
            {
                BlockReceiver = receiver;
            }

            protected override void Traversing(in AsmCodeBlock src)
            {
                BlockReceiver(BlockOrigin, src);
            }

            protected override void Traversing(in AsmCodeBlocks src)
            {
                BlockOrigin = src.Origin;
            }
        }
    }


}