//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct SymHeaps
    {
        public static SymHeap<K,uint,ushort> heap<K>()
            where K : unmanaged, Enum
        {
            var symbols = Symbols.index<K>();
            var kinds = symbols.Kinds;
            var buffer = text.buffer();
            var count = symbols.Count;
            var offsets = alloc<uint>(count);
            var lengths = alloc<ushort>(count);
            var entries = alloc<SymHeapEntry<K,uint,ushort>>(count);
            var offset = 0u;
            for(var i=0; i<symbols.Count; i++)
            {
                ref var entry = ref seek(entries,i);
                ref readonly var symbol = ref symbols[i];
                var expr = symbol.Expr.Data;
                var length = (ushort)expr.Length;
                entry = new SymHeapEntry<K, uint, ushort>(symbol.Kind, offset, length);
                buffer.Append(expr);
                offset += length;
            }

            return new SymHeap<K,uint,ushort>(entries,buffer.Emit());
        }

        [MethodImpl(Inline)]
        public static SymHeapEntry<K,A,T> entry<K,A,T>(K key, A offset, T length)
            where K : unmanaged
            where A : unmanaged
            where T : unmanaged
                => new SymHeapEntry<K, A, T>(key, offset, length);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> expr(SymHeap src, uint index)
            => slice(src.ExprData.View, src.ExprOffsets[index], src.ExprLengths[index]);

        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<kSrc; i++)
                counter += (uint)skip(src,i).Symbol.CharCount;
            return counter;
        }

        [Op]
        public static Index<SymHeapEntry> entries(SymHeap src)
        {
            var count = src.SymbolCount;
            var entries = alloc<SymHeapEntry>(count);
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref seek(entries,i);
                entry.Key = i;
                entry.Offset = src.Offset(i);
                entry.Source = src.Source(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = text.format(src.Expression(i));
            }
            return entries;
        }

        [Op]
        public static SymHeap create(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var count = (uint)src.Length;
            var kEntry = (uint)bits.next((Pow2x32)bits.xmsb(count));
            dst.SymbolCount = count;
            dst.EntryCount = kEntry;
            dst.ExprLengths = alloc<uint>(kEntry);
            dst.Values = alloc<SymVal>(kEntry);
            dst.Names = alloc<Identifier>(kEntry);
            dst.ExprData = alloc<char>(charcount(src));
            dst.ExprOffsets = alloc<uint>(kEntry);
            dst.Sources = alloc<Identifier>(kEntry);
            ref var exprwidths = ref dst.ExprLengths.First;
            ref var values = ref dst.Values.First;
            ref var symdst = ref dst.ExprData.First;
            ref var offsets = ref dst.ExprOffsets.First;

            ref var id = ref dst.Names.First;
            ref var sources = ref dst.Sources.First;
            var exprOffset=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                var symsrc = row.Symbol.Data;
                var namesrc = span(row.Name.Text);
                var width = (ushort)symsrc.Length;
                seek(exprwidths, i) = (ushort)symsrc.Length;
                seek(values, i) = row.Value;
                seek(id, i) = row.Name;
                seek(offsets,i) = exprOffset;
                seek(sources,i) = row.Type;
                symsrc.CopyTo(cover(seek(symdst, exprOffset), (ushort)symsrc.Length));

                exprOffset += width;
            }

            return dst;
        }
    }
}