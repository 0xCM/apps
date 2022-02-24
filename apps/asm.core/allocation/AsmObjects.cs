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