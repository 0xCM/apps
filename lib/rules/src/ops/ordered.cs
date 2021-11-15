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
        [Op]
        public static Ordered ordered()
            => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Ordered<T> ordered<T>()
            where T : IComparable<T>
                => default;
    }
}