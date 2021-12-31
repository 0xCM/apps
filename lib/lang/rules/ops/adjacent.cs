//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Rules;

    partial struct rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Adjacent<T> adjacent<T>(T a, T b)
            => new Adjacent<T>(a, b);
   }
}