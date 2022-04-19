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
        /// <summary>
        /// Determines the address of a character string at a specified offset
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(MemoryStrings src, int index)
            => core.address(chars(src, index));

        /// <summary>
        /// Determines the address of a character string at a specified offset
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(MemoryStrings src, uint index)
            => core.address(chars(src, index));

        [MethodImpl(Inline), Op]
        public static StringAddress address(string src)
            => new StringAddress(core.address(src));

        [MethodImpl(Inline), Op]
        public static StringAddress address(ReadOnlySpan<char> src)
            => new StringAddress(core.address(src));

        [MethodImpl(Inline), Op]
        public static StringAddress address<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new StringAddress(core.address(src));
    }
}