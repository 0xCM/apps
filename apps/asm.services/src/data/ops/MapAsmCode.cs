//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System.Linq;

    using static core;

    partial class ProjectDataServices
    {
        // public void MapAsmCode(IProjectWs project, Alloc dispenser)
        // {
        //     var entries = MapAsmCode(project, AsmObjects.LoadRows(project), dispenser);
        //     TableEmit(entries.View, AsmCodeMapEntry.RenderWidths, Projects.Table<AsmCodeMapEntry>(project));
        // }

        // Index<AsmCodeMapEntry> MapAsmCode(IProjectWs project, Index<ObjDumpRow> src, Alloc dispenser)
        // {
        //     var distilled = DistillBlocks(project, src, dispenser);
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
        //                 entry.Seq = c.Seq;
        //                 entry.DocSeq = c.DocSeq;
        //                 entry.EncodingId = c.EncodingId;
        //                 entry.OriginId = blocks.OriginId;
        //                 entry.InstructionId = AsmBytes.instid(blocks.OriginId, c.IP, c.Encoding);
        //                 entry.OriginName = blocks.OriginName;
        //                 entry.BlockNumber = blocknumber;
        //                 entry.BlockName = name;
        //                 entry.BlockAddress = address;
        //                 entry.IP = c.IP;
        //                 entry.Size = c.EncodingSize;
        //                 entry.Encoded = c.Encoded;
        //                 entry.Asm = c.Asm;
        //                 entry.BlockSize = block.Size;
        //                 entries.Add(entry);
        //             }

        //             blocknumber++;
        //         }
        //     }

        //     var records = entries.ToArray().Sort();
        //     return records;
        // }

        // Index<AsmCodeBlocks> DistillBlocks(IProjectWs project, Index<ObjDumpRow> src, Alloc dispenser)
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
        //                 var encoding = new AsmEncodingInfo();
        //                 encoding.Seq = row.Seq;
        //                 encoding.DocSeq = row.DocSeq;
        //                 encoding.EncodingId = row.EncodingId;
        //                 encoding.OriginId = row.OriginId;
        //                 encoding.IP = row.IP;
        //                 encoding.Encoded = row.Encoded.Bytes;
        //                 encoding.InstructionId = row.InstructionId;
        //                 encoding.Size = row.Size;
        //                 encoding.Asm = row.Asm.Content;
        //                 seek(codebuffer,k) = dispenser.AsmCode(encoding);
        //             }

        //             seek(blockbuffer,j) = new AsmCodeBlock(dispenser.Symbol(blockaddress, blockname), codebuffer);
        //         }

        //         var origin = project.FileCatalog().Entry(group.Key);
        //         seek(buffer,i) = new AsmCodeBlocks(dispenser.Label(origin.DocName), origin.DocId, blockbuffer);
        //     }
        //     return buffer;
        // }
    }
}