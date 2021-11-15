//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial struct sys
    {
        /// <summary>
        /// Projects the source onto its textual representation
        /// </summary>
        /// <param name="src">The source</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static string @string<T>(T src)
            => proxy.@string(src);

        [MethodImpl(Options), Op]
        public static unsafe string @string(char* pSrc)
            => proxy.@string(pSrc);

        [MethodImpl(Options), Op]
        public static string @string(ReadOnlySpan<char> src)
            => proxy.@string(src);
    }
}