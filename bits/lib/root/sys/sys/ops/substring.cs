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
        [MethodImpl(Options), Op]
        public static string substring(string src, int startidx)
            => proxy.substring(src, startidx);

        [MethodImpl(Options), Op]
        public static string substring(string src, int startidx, int len)
            => proxy.substring(src, startidx, len);
    }
}