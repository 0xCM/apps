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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRefs<S> embedded<S>(ReadOnlySpan<S> src)
            where S : unmanaged
                => new StringRefs<S>(src);

        [MethodImpl(Inline), Op]
        public static StringRefs<char> embedded(string src)
            => new StringRefs<char>(src);

        [MethodImpl(Inline), Op]
        public static StringRefs<char> embedded(ReadOnlySpan<char> src)
            => new StringRefs<char>(src);
    }
}