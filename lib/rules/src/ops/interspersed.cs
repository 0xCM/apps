//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Interspersal<T> interspersed<T>(Index<T> terms, Intersperse<T> rule)
            => new Interspersal<T>(terms, rule);
    }
}