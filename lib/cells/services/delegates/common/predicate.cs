//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Delegates
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static UnaryPredicate<T> predicate<T>(System.Func<T,bit> f)
            => new UnaryPredicate<T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Z0.BinaryPredicate<T> predicate<T>(System.Func<T,T,bit> f)
            => new Z0.BinaryPredicate<T>(f);
    }
}