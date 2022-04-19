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
        public static TypeCode typecode<T>()
            => proxy.typecode<T>();

        [MethodImpl(Options), Op]
        public static TypeCode typecode(Type src)
            => proxy.typecode(src);
    }
}