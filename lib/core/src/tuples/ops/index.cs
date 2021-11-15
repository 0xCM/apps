//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Tuples
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Pairs<T> index<T>(Pair<T>[] src)
            where T : unmanaged
                => src;
    }
}