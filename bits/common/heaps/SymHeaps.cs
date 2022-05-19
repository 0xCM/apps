//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(StructLayout,Pack=1)]
    public struct SymHeapStats
    {
        public uint SymbolCount;

        public uint EntryCount;

        public uint CharCount;

        public uint DataSize;
    }

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
                => new SymHeapEntry<K,A,T>(key, offset, length);

        [MethodImpl(Inline), Op]
        public static uint charcount(ReadOnlySpan<SymLiteralRow> src)
        {
            var counter = 0u;
            var kSrc = src.Length;
            for(var i=0; i<src.Length; i++)
                counter += skip(src,i).Symbol.CharCount;
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
                entry.Size = src.Size(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = text.format(src.Expression(i));
            }
            return entries;
        }

        public static SymHeapStats stats(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeapStats();
            dst.SymbolCount = (uint)src.Length;
            dst.EntryCount = (uint)bits.next((Pow2x32)bits.xmsb(dst.SymbolCount));
            dst.CharCount = charcount(src);
            dst.DataSize = dst.CharCount*2;
            return dst;
        }
        [Op]
        public static SymHeap create(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var stats = SymHeaps.stats(src);
            dst.SymbolCount = stats.SymbolCount;;
            dst.EntryCount = stats.EntryCount;
            dst.ExprLengths = alloc<uint>(stats.EntryCount);
            dst.Expr = alloc<char>(stats.CharCount);
            dst.ExprOffsets = alloc<uint>(stats.EntryCount);
            dst.Values = alloc<SymVal>(stats.EntryCount);
            dst.Names = alloc<Identifier>(stats.EntryCount);
            dst.Sources = alloc<Identifier>(stats.EntryCount);
            var offset=0u;
            for(var i=0u; i<dst.SymbolCount; i++)
            {
                ref readonly var row = ref skip(src,i);
                var chars = row.Symbol.Data;
                var length = (uint)chars.Length;
                dst.Length(i) = length;
                dst.Value(i) = row.Value;
                dst.Name(i) = row.Name;
                dst.Offset(i) = offset;
                dst.Source(i) = row.Type;
                chars.CopyTo(dst.Expression(i));
                offset += (length*2);
            }

            return dst;
        }
    }
}