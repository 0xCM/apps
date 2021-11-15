//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;

    using O = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(O.UnboxObject), Closures(Closure)]
        public static ref T unbox<T>(object src)
            where T : struct
                => ref Unbox<T>(src);

        [MethodImpl(Options), Opaque(O.UnboxEnum), Closures(Closure)]
        public static ref T unbox<T>(Enum src)
            where T : unmanaged
                => ref Unbox<T>(src);
    }
}