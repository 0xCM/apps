//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct strings
    {
        [MethodImpl(Inline), Op]
        public static MemoryStrings memory(uint entries, uint length, MemoryAddress offsetbase, MemoryAddress charbase)
            => new MemoryStrings(entries, length, offsetbase, charbase);

        [MethodImpl(Inline), Op]
        public static MemoryStrings memory(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            => new MemoryStrings(ecount(offsets), (uint)chars.Length, core.address(offsets), core.address(chars));

        [MethodImpl(Inline)]
        public static MemoryStrings<K> memory<K>(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            where K : unmanaged
                => new MemoryStrings<K>(memory(offsets, chars));

        [MethodImpl(Inline), Op]
        static uint ecount(ReadOnlySpan<byte> offsets)
            => (uint)(offsets.Length/4);
    }
}