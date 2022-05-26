//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        /// <summary>
        /// Computes a <see cref='SymHeap'/> for a parametrically-identified symbol type
        /// </summary>
        /// <typeparam name="E">The symbol type</typeparam>
        public static SymHeap symbols<E>()
            where E : unmanaged, Enum
                => symbols(symlits<E>());

        public static SymHeap<K,uint,ushort> symbols<K>(W32 wKey, W16 wVal)
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
                entry = new SymHeapEntry<K,uint,ushort>(symbol.Kind, offset, length);
                buffer.Append(expr);
                offset += length;
            }

            return new SymHeap<K,uint,ushort>(entries,buffer.Emit());
        }

        [Op]
        public static SymHeap symbols(ReadOnlySpan<SymLiteralRow> src)
        {
            var dst = new SymHeap();
            var stats = Heaps.stats(src);
            dst.SymbolCount = stats.SymbolCount;;
            dst.EntryCount = stats.EntryCount;
            dst.ExprLengths = alloc<uint>(stats.EntryCount);
            dst.CharCount = stats.CharCount;
            dst.Expr = alloc<char>(stats.CharCount);
            dst.ExprOffsets = alloc<uint>(stats.EntryCount);
            dst.Values = alloc<SymVal>(stats.EntryCount);
            dst.Names = alloc<Identifier>(stats.EntryCount);
            dst.Sources = alloc<Identifier>(stats.EntryCount);
            var size=0u;
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
                Demand.lteq(offset + length, stats.CharCount);
                chars.CopyTo(slice(dst.Expr.Edit, offset, length));
                offset += length;
                size += length*2;
            }

            return dst;
        }
    }
}