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
        [MethodImpl(Options), Opaque(GetGenericTypeCode), Closures(Closure)]
        public static TypeCode typecode<T>()
            => Type.GetTypeCode(typeof(T));

        [MethodImpl(Options), Opaque(GetTypeCode)]
        public static TypeCode typecode(Type src)
            => Type.GetTypeCode(src);
    }
}