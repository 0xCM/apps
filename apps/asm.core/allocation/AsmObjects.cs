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
        public AsmCodeBlocks DistillBlocks(WsContext context, in FileRef file, ref uint seq, Index<ObjDumpRow> src, Alloc dispenser)
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
                    var encoding = new AsmEncodingInfo();
                    encoding.Seq = seq++;
                    encoding.DocSeq = row.DocSeq;
                    encoding.EncodingId = row.EncodingId;
                    encoding.OriginId = row.OriginId;
                    encoding.InstructionId = row.InstructionId;
                    encoding.IP = row.IP;
                    encoding.Encoded = row.Encoded.Bytes;
                    encoding.Size = row.Size;
                    encoding.Asm = row.Asm;
                    seek(codebuffer,k) = dispenser.AsmCode(encoding);
                }
                seek(blockbuffer,i) = new AsmCodeBlock(dispenser.Symbol(blockaddress,blockname), codebuffer);
            }
            var origin = context.Root(file);
            return new AsmCodeBlocks(dispenser.Label(origin.DocName), origin.DocId, blockbuffer);
        }
    }
}