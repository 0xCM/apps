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
                => symbols(Symbolic.literals<E>());

        /// <summary>
        /// Reconstitutes a <see cref='SymHeap{K,O,L}'/> indexed by <typeparamref name='K'> values with <typeparamref name='O'>-measured offsets and <typeparamref name='L'>-measured lengths
        /// </summary>
        /// <param name="entries"></param>
        /// <param name="data"></param>
        /// <typeparam name="K">The linear index type</typeparam>
        /// <typeparam name="O">The offset type</typeparam>
        /// <typeparam name="L">The length type</typeparam>
        [MethodImpl(Inline)]
        public static SymHeap<K,O,L> symbols<K,O,L>(ReadOnlySpan<byte> entries, ReadOnlySpan<char> data)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => new SymHeap<K,O,L>(recover<HeapEntry<K,O,L>>(entries), data);

        /// <summary>
        /// Creates a <see cref='SymHeap{K,O,L}'/> indexed by <typeparamref name='K'> values with <typeparamref name='O'>-measured offsets and <typeparamref name='L'>-measured lengths
        /// </summary>
        /// <typeparam name="K">The linear index type</typeparam>
        /// <typeparam name="O">The offset type</typeparam>
        /// <typeparam name="L">The length type</typeparam>
        public static SymHeap<K,O,L> symbols<K,O,L>()
            where K : unmanaged, Enum
            where O : unmanaged
            where L : unmanaged
        {
            var symbols = Symbols.index<K>();
            var count = symbols.Count;
            var content = text.buffer();
            var offsets = span<O>(count);
            var lengths = span<L>(count);
            var entries = span<HeapEntry<K,O,L>>(count);
            var offset = 0u;
            for(var i=0; i<symbols.Count; i++)
            {
                var expr = symbols[i].Expr.Data;
                var length = (uint)expr.Length;
                seek(entries,i) = new HeapEntry<K,O,L>(symbols[i].Kind, @as<uint,O>(offset), @as<uint,L>(length));
                content.Append(expr);
                offset += length;
            }
            return new SymHeap<K,O,L>(entries,content.Emit());
        }

        public static SymHeap<K,byte,byte> symbols<K>(W8 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,byte,byte>();

        public static SymHeap<K,ushort,byte> symbols<K>(W16 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,byte>();

        public static SymHeap<K,ushort,ushort> symbols<K>(W16 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,ushort>();

        public static SymHeap<K,uint,byte> symbols<K>(W32 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,byte>();

        public static SymHeap<K,uint,ushort> symbols<K>(W32 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,ushort>();

        /// <summary>
        /// Creates a <see cref='SymHeap'/> from a specified <see cref='SymLiteralRow'/> sequence
        /// </summary>
        /// <param name="src">The data source</param>
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