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
            //var src = ObjDump.LoadRows()
            var project = Project();
            var path = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var src = ObjDump.LoadRows(path);
            var count = src.Count;
            var collector = new AsmBlockCollector();
            var collected = dict<string, AsmCodeBlocks>();
            using var dispenser = AsmDispenser.create();

            var docid = src.First.DocId;
            var docname = src.First.Source.Path.FileName.Format();
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                if(src[i].DocId != docid)
                {
                    collected.Add(docname, Collect(docname,slice(src.View,offset,length), dispenser));
                    offset = i;
                    length = 0;
                    docname = src[i].Source.Path.FileName.Format();
                    docid = src[i].DocId;
                }

                length++;
            }

            if(length != 0)
            {
                collected.Add(docname, Collect(docname,slice(src.View,offset,length), dispenser));
            }

            foreach(var name in collected.Keys)
            {
                var dst = ProjectDb.Subdir("asm") + FS.file(string.Format("{0}.code", name), FS.Csv);
                Emit(collected[name], dst);
            }


            return true;
        }

        AsmCodeBlocks Collect(text31 origin, ReadOnlySpan<ObjDumpRow> src, AsmDispenser dispenser)
        {
            var collector = new AsmBlockCollector();
            var count = src.Length;
            for(var i=0; i<count; i++)
                collector.Include(src[i]);
            return dispenser.AsmCodeBlocks(origin, collector.Emit());
        }

        void Emit(in AsmCodeBlocks src, FS.FilePath dst)
        {
            var buffer = alloc<AsmCodeRecord>(src.LineCount);
            var k=0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.LineCount;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Origin = src.Origin;
                    record.BlockAddress = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Encoded = code.Encoded;
                    record.Size = code.Encoded.Size;
                    record.Asm = code.Asm;
                }
            }
            TableEmit(@readonly(buffer), AsmCodeRecord.RenderWidths, dst);
        }
    }
}