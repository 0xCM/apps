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
        WsProjects Projects => Service(Wf.WsProjects);

        // public static AsmEncodingRecord encoding<T>(in T src)
        //     where T : IAsmBlockSegment
        // {
        //     var encoding = new AsmEncodingRecord();
        //     encoding.Seq = src.Seq;
        //     encoding.EncodingId = src.EncodingId;
        //     encoding.OriginId = src.OriginId;
        //     encoding.IP = src.IP;
        //     encoding.Encoded = src.Encoded.Bytes;
        //     encoding.Size = src.Size;
        //     encoding.Asm = src.Asm;
        //     return encoding;
        // }

        // public Index<AsmCodeMapEntry> MapCode(WsContext context, Index<AsmCodeIndexRow> index, Index<ObjDumpRow> src, Alloc dispenser)
        // {
        //     var project = context.Project;
        //     var distilled = DistillBlocks(context, src, dispenser);
        //     var entries = list<AsmCodeMapEntry>();
        //     for(var i=0; i<distilled.Count; i++)
        //     {
        //         ref readonly var blocks = ref distilled[i];
        //         if(blocks.Count == 0)
        //             continue;

        //         var blocknumber = 0u;
        //         var @base = MemoryAddress.Zero;

        //         for(var j=0; j<blocks.Count; j++)
        //         {
        //             ref readonly var block = ref blocks[j];
        //             var count = block.Count;
        //             ref readonly var address = ref block.Label.Location.Address;
        //             ref readonly var name = ref block.Label.Name;
        //             for(var k=0; k<count; k++)
        //             {
        //                 ref readonly var c = ref block[k];

        //                 if(j==0 && k==0)
        //                     @base = c.Encoded.BaseAddress;

        //                 var entry = new AsmCodeMapEntry();
        //                 entry.EncodingId = c.EncodingId;
        //                 entry.OriginId = blocks.OriginId;
        //                 entry.OriginName = blocks.OriginName;
        //                 entry.BlockNumber = blocknumber;
        //                 entry.BlockName = name;
        //                 entry.BlockAddress = address;
        //                 entry.IP = c.IP;
        //                 entry.EncodingSize = c.EncodingSize;
        //                 entry.Encoded = c.Encoded;
        //                 entry.Asm = c.Asm;
        //                 entry.BlockSize = block.Size;
        //                 entries.Add(entry);
        //             }

        //             blocknumber++;
        //         }
        //     }
        //     return entries.ToArray().Sort();
        // }


        public AsmCodeBlocks DistillBlocks(WsContext context, in FileRef file, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var blocks = src.GroupBy(x => x.BlockAddress).Array();
            var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
            for(var i=0; i<blocks.Length; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var blockcode = block.Array();
                var blockname = first(blockcode).BlockName.Format();
                var blockaddress = block.Key;
                var codebuffer = alloc<AsmCode>(blockcode.Length);
                for(var k=0; k<blockcode.Length; k++)
                {
                    ref readonly var row = ref skip(blockcode,k);
                    var encoding = new AsmEncodingRecord();
                    encoding.Seq = row.Seq;
                    encoding.EncodingId = row.EncodingId;
                    encoding.OriginId = row.OriginId;
                    encoding.IP = row.IP;
                    encoding.Encoded = row.Encoded.Bytes;
                    encoding.Size = row.Size;
                    encoding.Asm = row.Asm;
                    seek(codebuffer,k) = dispenser.AsmCode(encoding);
                }
                seek(blockbuffer,i) = new AsmCodeBlock(dispenser.Symbol(blockaddress,blockname), codebuffer);
            }
            var originated = context.Root(file.Path, out var origin);
            return new AsmCodeBlocks(dispenser.Label(origin.Path.FileName.Format()), origin.DocId, blockbuffer);
        }

        // public Index<AsmCodeBlocks> DistillBlocks(WsContext context, Index<ObjDumpRow> src, Alloc dispenser)
        // {
        //     var collected = dict<uint, AsmCodeBlocks>();
        //     var groups = src.GroupBy(x => x.OriginId).Array();
        //     var buffer = alloc<AsmCodeBlocks>(groups.Length);
        //     for(var i=0; i<groups.Length; i++)
        //     {
        //         ref readonly var group = ref skip(groups,i);
        //         var blocks = group.ToArray().GroupBy(x => x.BlockName).Array();
        //         if(blocks.Length == 0)
        //             continue;

        //         var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
        //         for(var j=0; j<blocks.Length; j++)
        //         {
        //             ref readonly var block = ref skip(blocks,j);
        //             var blockcode = block.Array();
        //             if(blockcode.Length == 0)
        //                 continue;

        //             var blockname = block.Key.Format();
        //             var blockaddress = first(blockcode).BlockAddress;
        //             var codebuffer = alloc<AsmCode>(blockcode.Length);
        //             for(var k=0; k<blockcode.Length; k++)
        //             {
        //                 ref readonly var row = ref skip(blockcode,k);
        //                 var encoding = new AsmEncodingRecord();
        //                 encoding.Seq = row.Seq;
        //                 encoding.EncodingId = row.EncodingId;
        //                 encoding.OriginId = row.OriginId;
        //                 encoding.IP = row.IP;
        //                 encoding.Encoded = row.Encoded.Bytes;
        //                 encoding.Size = row.Size;
        //                 encoding.Asm = row.Asm;
        //                 seek(codebuffer,k) = dispenser.AsmCode(encoding);
        //             }

        //             seek(blockbuffer,j) = new AsmCodeBlock(dispenser.Symbol(blockaddress, blockname), codebuffer);
        //         }

        //         var origin = context.FileRef(group.Key);
        //         seek(buffer,i) = new AsmCodeBlocks(dispenser.Label(origin.Path.FileName.Format()), origin.DocId, blockbuffer);
        //     }
        //     return buffer;
        // }

        public void Emit(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
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
                    record.EncodingId = code.EncodingId;
                    record.OriginId = code.OriginId;
                    record.OriginName = src.OriginName;
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Encoded = code.Encoded;
                    record.Size = code.Encoded.Size;
                    record.Asm = code.Asm;

                    if(!distinct.Add(record.EncodingId))
                    {
                        Warn(string.Format("Duplicate identifier:{0}", record.EncodingId));
                    }
                }
            }

            TableEmit(@readonly(buffer), AsmCodeRecord.RenderWidths, dst);
        }
    }
}