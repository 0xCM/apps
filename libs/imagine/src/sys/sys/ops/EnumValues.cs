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
        public static Enum[] EnumValues(Type src)
            => proxy.EnumValues(src);

        [MethodImpl(Options)]
        public static T[] EnumValues<T>()
            where T : unmanaged, Enum
                => proxy.EnumValues(typeof(T)).Cast<T>();
    }
}