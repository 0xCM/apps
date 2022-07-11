//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free, ApiHost]
    public partial class Heaps
    {
        const NumericKind Closure = UnsignedInts;

        public static asci16 id(SymHeap src)
            => string.Format("H{0:X4}x{1:X4}x{2:X6}", src.SymbolCount, src.EntryCount, src.ExprLengths.Storage.Sum());

        [MethodImpl(Inline), Op]
        public static Span<char> expr(SymHeap src, uint index)
            => core.slice(src.Expr.Edit, src.ExprOffsets[index], src.ExprLengths[index]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Heap<T> create<T>(T[] src, uint[] offsets)
            => new Heap<T>(src, offsets);

        [MethodImpl(Inline)]
        public static Heap<K,T> create<K,T>(T[] src, Index<K,uint> offsets)
            where K : unmanaged
                => new Heap<K,T>(src, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SpanHeap<T> create<T>(Span<T> src, uint[] offsets)
            => new SpanHeap<T>(src, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlyHeap<T> create<T>(ReadOnlySpan<T> src, uint[] offsets)
            => new ReadOnlyHeap<T>(src, offsets);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryHeap<T> retype<T>(in BinaryHeap src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BinaryHeap untype<T>(in BinaryHeap<T> src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static ReadOnlySpan<byte> serialize<K,O,L>(in HeapEntry<K,O,L> src)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
                => bytes(src);

        [MethodImpl(Inline)]
        public static ref HeapEntry<K,O,L> materialize<K,O,L>(ReadOnlySpan<byte> src, out HeapEntry<K,O,L> dst)
            where K : unmanaged
            where O : unmanaged
            where L : unmanaged
        {
            dst = @as<HeapEntry<K,O,L>>(src);
            return ref dst;
        }
   }
}