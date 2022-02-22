//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System.Linq;

    using static core;

    public class AsmObjects : AppService<AsmObjects>
    {
        static AsmEncoding encoding<T>(in T src)
            where T : IAsmBlockSegment
        {
            var encoding = new AsmEncoding();
            encoding.Seq = src.Seq;
            encoding.Id = src.Id;
            encoding.IP = src.IP;
            encoding.Encoded = src.Encoded.Bytes;
            encoding.Size = src.Size;
            encoding.Asm = src.Asm;
            return encoding;
        }

        public Index<AsmCodeMapEntry> MapCode(IProjectWs project, Index<AsmCodeIndexRow> index, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var catalog = project.FileCatalog();
            var distilled = DistillBlocks(project, src, dispenser);
            var entries = list<AsmCodeMapEntry>();
            for(var i=0; i<distilled.Count; i++)
            {
                ref readonly var blocks = ref distilled[i];
                if(blocks.Count == 0)
                    continue;

                ref readonly var origin = ref blocks.Origin;

                var blocknumber = 0u;
                var @base = MemoryAddress.Zero;

                for(var j=0; j<blocks.Count; j++)
                {
                    ref readonly var block = ref blocks[j];
                    var count = block.Count;
                    ref readonly var address = ref block.Label.Location.Address;
                    ref readonly var name = ref block.Label.Name;
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var c = ref block[k];

                        if(j==0 && k==0)
                            @base = c.Encoded.BaseAddress;

                        var entry = new AsmCodeMapEntry();
                        entry.Id = c.Id;
                        entry.MappedAddress = c.Encoded.BaseAddress;
                        entry.MappedRebase = c.Encoded.BaseAddress - @base;
                        entry.Origin = origin;
                        entry.BlockNumber = blocknumber;
                        entry.BlockName = name;
                        entry.BlockAddress = address;
                        entry.EntryAddress = c.IP;
                        entry.EncodingSize = c.EncodingSize;
                        entry.Encoded = c.Encoded;
                        entry.Asm = c.Asm;
                        entry.BlockSize = block.Size;
                        entries.Add(entry);
                    }

                    blocknumber++;
                }
            }
            return entries.ToArray();
        }

        public AsmCodeBlocks DistillBlocks(in FileRef file, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var blocks = src.GroupBy(x => x.BlockAddress).Array();
            var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
            var origin = dispenser.Label(file.Path.FileName.Format());
            for(var i=0; i<blocks.Length; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var blockcode = block.Array();
                var blockname = first(blockcode).BlockName.Format();
                var blockaddress = block.Key;
                var codebuffer = alloc<AsmCode>(blockcode.Length);
                for(var k=0; k<blockcode.Length; k++)
                    seek(codebuffer,k) = dispenser.AsmCode(encoding(skip(blockcode,k)));
                seek(blockbuffer,i) = new AsmCodeBlock(dispenser.Symbol(blockaddress,blockname), codebuffer);
            }
            return new AsmCodeBlocks(origin, blockbuffer);
        }

        public Index<AsmCodeBlocks> DistillBlocks(IProjectWs project, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var collected = dict<uint, AsmCodeBlocks>();
            var groups = src.GroupBy(x => x.DocName).Array();
            var buffer = alloc<AsmCodeBlocks>(groups.Length);
            for(var i=0; i<groups.Length; i++)
            {
                ref readonly var group = ref skip(groups,i);
                var origin = dispenser.Label(group.Key);
                var blocks = group.ToArray().GroupBy(x => x.BlockName).Array();
                var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);

                    var blockcode = block.Array();
                    if(blockcode.Length == 0)
                        continue;

                    var blockname = block.Key.Format();
                    var blockaddress = first(blockcode).BlockAddress;
                    var codebuffer = alloc<AsmCode>(blockcode.Length);
                    for(var k=0; k<blockcode.Length; k++)
                    {
                        var e = encoding(skip(blockcode,k));

                        seek(codebuffer,k) = dispenser.AsmCode(e);
                    }

                    seek(blockbuffer,j) = new AsmCodeBlock(dispenser.Symbol(blockaddress,blockname), codebuffer);
                }

                seek(buffer,i) = new AsmCodeBlocks(origin, blockbuffer);
            }
            return buffer;
        }

        public void Emit(ReadOnlySpan<AsmCodeBlocks> src, FS.FolderPath dir)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var blocks = ref skip(src,i);
                var dst = dir + FS.file(string.Format("{0}.code", blocks.Origin), FS.Csv);
                Emit(blocks,dst);
            }
        }

        public void Emit(in AsmCodeBlocks src, FS.FilePath dst)
        {
            var buffer = alloc<AsmCodeRecord>(src.LineCount);
            var k=0u;
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.Count;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Id = AsmBytes.encid(code.IP, code.Encoding);
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Encoded = code.Encoded;
                    record.Size = code.Encoded.Size;
                    record.Asm = code.Asm;
                    record.Origin = src.Origin;

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