//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Heaps
    {
        [Op]
        public static Index<SymHeapEntry> entries(SymHeap src)
        {
            var count = src.SymbolCount;
            var entries = alloc<SymHeapEntry>(count);
            var remains = src.CharCount*2;
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref seek(entries,i);
                remains -= src.Size(i);
                entry.Key = i;
                entry.Offset = src.Offset(i)*2;
                entry.Size = src.Size(i);
                entry.Remains = remains;
                entry.Source = src.Source(i);
                entry.Name = src.Name(i);
                entry.Value = src.Value(i);
                entry.Expression = text.format(src.Symbol(i));
            }
            return entries;
        }

        [MethodImpl(Inline)]
        public static SymHeapEntry<K,A,T> entry<K,A,T>(K key, A offset, T length)
            where K : unmanaged
            where A : unmanaged
            where T : unmanaged
                => new SymHeapEntry<K,A,T>(key, offset, length);
    }
}