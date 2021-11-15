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
        public static unsafe ReadOnlySpan<char> chars(in MemoryStrings src)
            => core.cover(src.CharBase.Pointer<char>(), src.CharCount);

        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<char> chars(MemoryAddress @base, int i0, int i1)
            => core.cover(@base.Pointer<char>() + i0, (i1 - i0));

        [MethodImpl(Inline), Op]
        public static unsafe ReadOnlySpan<char> chars(in MemoryStrings src, int index)
            => core.slice(chars(src), offset(src,index), length(src,index));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in MemoryStrings src, uint index)
            => chars(src, (int)index);
    }
}