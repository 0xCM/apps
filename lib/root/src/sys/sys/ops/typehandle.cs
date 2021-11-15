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
        public static IntPtr handle(Type src) 
            => proxy.handle(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static IntPtr handle<T>() 
            => proxy.handle<T>();
    }
}