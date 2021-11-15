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
        [MethodImpl(Options), Op, Closures(Closure)]                
        public static Type type<T>()
            => proxy.type<T>();

        [MethodImpl(Options), Op]
        public static Type type(object src)
            => proxy.type(src);
    }
}