//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(ArrayToList), Closures(Closure)]
        public static List<T> list<T>(params T[] src)
            => src.ToList();
    }
}