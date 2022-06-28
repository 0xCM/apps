//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(Substring)]
        public static string substring(string src, int startidx)
            => src?.Substring(startidx) ?? EmptyString;

        [MethodImpl(Options), Opaque(Substring)]
        public static string substring(string src, int startidx, int len)
            => src?.Substring(startidx, len) ?? EmptyString;
    }
}