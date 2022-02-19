//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public class AsmObjects : AppService<AsmObjects>
    {
        public ConstLookup<string,AsmCodeBlocks> DistillBlocks(ReadOnlySpan<ObjDumpRow> src, AsmDispenser dispenser)
        {
            var count = src.Length;
            var collector = new AsmBlockCollector();
            var collected = dict<string, AsmCodeBlocks>();
            var docid = first(src).DocId;
            var docname = first(src).Source.Path.FileName.Format();
            var length = 0u;
            var offset = 0u;
            for(var i=0u; i<count; i++)
            {
                if(skip(src,i).DocId != docid)
                {
                    collected.Add(docname, Collect(docname,slice(src, offset, length), dispenser));
                    offset = i;
                    length = 0;
                    docname = skip(src,i).Source.Path.FileName.Format();
                    docid = skip(src,i).DocId;
                }

                length++;
            }

            if(length != 0)
            {
                collected.Add(docname, Collect(docname,slice(src, offset,length), dispenser));
            }

            return collected;
        }

        public void Emit(ConstLookup<string,AsmCodeBlocks> src, FS.FolderPath dir)
        {
            var names = src.Keys;
            var count = names.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(names,i);
                var dst = dir + FS.file(string.Format("{0}.code", name), FS.Csv);
                Emit(src[name],dst);
            }
        }

        AsmCodeBlocks Collect(string origin, ReadOnlySpan<ObjDumpRow> src, AsmDispenser dispenser)
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
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.LineCount;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Origin = src.Origin;
                    record.Id = AsmBytes.identify(code.IP, code.Encoding);
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Encoded = code.Encoded;
                    record.Size = code.Encoded.Size;
                    record.Asm = code.Asm;

                    if(!distinct.Add(record.Id))
                    {
                        Warn(string.Format("Duplicate identifier:{0}", record.Id));
                    }
                }
            }


            TableEmit(@readonly(buffer), AsmCodeRecord.RenderWidths, dst);
        }

    }
}
