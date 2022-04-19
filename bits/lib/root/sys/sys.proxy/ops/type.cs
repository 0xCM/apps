//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using O = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(O.GetGenericType), Closures(Closure)]
        public static Type type<T>()
            => typeof(T);

        [MethodImpl(Options), Opaque(O.GetInstanceType)]
        public static Type type(object src)
            => src?.GetType() ?? typeof(void);
    }
}