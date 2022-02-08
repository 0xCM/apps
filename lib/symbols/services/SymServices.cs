//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Symbols;

    public class SymServices : AppService<SymServices>
    {
        public Index<SymKindRow> EmitSymKinds<K>(in Symbols<K> src, FS.FilePath dst)
            where K : unmanaged
        {
            var result = Outcome.Success;
            var kinds = src.Kinds;
            var count = kinds.Length;
            var buffer = alloc<SymKindRow>(count);
            Symbols.kinds(src,buffer);
            TableEmit(@readonly(buffer), SymKindRow.RenderWidths, dst);
            return buffer;
        }


        public Index<SymDetailRow> EmitSymDetails<E>()
            where E : unmanaged, Enum
        {
            var dst = Db.Table<SymDetailRow>(typeof(E).Name);
            var flow = Wf.EmittingTable<SymDetailRow>(dst);
            var symbols  = Symbols.index<E>().View;
            var count = symbols.Length;
            var buffer = alloc<SymDetailRow>(count);
            ref var target = ref first(buffer);
            var formatter = Tables.formatter<SymDetailRow>(SymDetailRow.RenderWidths);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                api.detail(symbol, (ushort)count, out seek(target,i));
                writer.WriteLine(formatter.Format(skip(target,i)));
            }
            Wf.EmittedTable(flow, count);
            return buffer;
        }

        public ByteSpanSpec GenBits(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var blocks = BitBlocks(w,start,end).View;
            var count = blocks.Length;
            var buffer = alloc<ByteSpanSpec>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var b = @bytes(block.Data);
                seek(dst,i) = SpanRes.specify(string.Format("Block{0:X2}", i), b.ToArray());
            }
            var merge = SpanRes.merge("CharBytes", buffer);
            var seg = merge.Segment(16,16);
            var chars = recover<char>(seg);
            return merge;
        }

        public Index<CharBlock8> BitBlocks(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock8>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = CharBlocks.alloc(n8);
                var data = block.Data;
                for(var j=0; j<8; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }

        public Index<CharBlock16> BitBlocks(W16 w, ushort start = 0, ushort end = ushort.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock16>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = CharBlocks.alloc(n16);
                var data = block.Data;
                for(var j=0; j<16; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }
    }
}