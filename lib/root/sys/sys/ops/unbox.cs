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
        public static ref T unbox<T>(object src)
            where T : struct
                => ref proxy.unbox<T>(src);

        [MethodImpl(Options), Op, Closures(Closure)]
        public static ref T unbox<T>(Enum src)
            where T : unmanaged
                => ref proxy.unbox<T>(src);
    }
}