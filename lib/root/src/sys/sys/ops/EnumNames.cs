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
        public static string[] EnumNames(Type src)
            => proxy.EnumNames(src);

        [MethodImpl(Options)]
        public static string[] EnumNames<T>()
            where T : unmanaged, Enum
                => proxy.EnumNames(typeof(T));
    }
}