//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    unsafe partial struct memory
    {
        [MethodImpl(Inline), Op]
        public static MemoryStrings strings(uint entries, uint length, MemoryAddress offsetbase, MemoryAddress charbase)
            => new MemoryStrings(entries, length, offsetbase, charbase);

        [MethodImpl(Inline), Op]
        public static MemoryStrings strings(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            => new MemoryStrings(MemoryStrings.count(offsets), (uint)chars.Length, core.address(offsets), core.address(chars));

        [MethodImpl(Inline)]
        public static MemoryStrings<K> strings<K>(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            where K : unmanaged
                => new MemoryStrings<K>(strings(offsets, chars));
    }
}