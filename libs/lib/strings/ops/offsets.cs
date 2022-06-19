//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static unsafe ref readonly uint offset(in MemoryStrings strings, int index)
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*4));
            return ref skip(src,index);
        }

        [MethodImpl(Inline), Op]
        public static unsafe ref readonly uint offset<K>(in MemoryStrings<K> strings, uint index)
            where K : unmanaged
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*4));
            return ref skip(src, index);
        }

        [MethodImpl(Inline), Op]
        public static unsafe ref readonly uint offset<K>(in MemoryStrings<K> strings, K index)
            where K : unmanaged
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*4));
            return ref skip(src, bw32(index));
        }

        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<uint> offsets(in MemoryStrings src)
            => recover<uint>(cover(src.OffsetBase.Pointer<byte>(), src.EntryCount*4));
    }
}