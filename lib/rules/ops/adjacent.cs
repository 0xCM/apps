//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AdjacentRule<T> adjacent<T>(T a, T b)
            => new AdjacentRule<T>(a, b);
   }
}