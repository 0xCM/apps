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
        [MethodImpl(Options), Opaque(GetEmptyArray), Closures(Closure)]
        public static T[] empty<T>()
            => Array.Empty<T>();
    }
}