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
        [MethodImpl(Options), Opaque(GetTypeHandle)]
        public static IntPtr handle(Type src)
            => src.TypeHandle.Value;

        [MethodImpl(Options), Opaque(GetGenericTypeHandle), Closures(Closure)]
        public static IntPtr handle<T>()
            => typeof(T).TypeHandle.Value;
    }
}