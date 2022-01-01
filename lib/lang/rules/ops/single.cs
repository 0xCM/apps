//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Rules;

    using static Root;

    partial struct rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Single<T> single<T>(T term)
            => new Single<T>(term);
    }
}