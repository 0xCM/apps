//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static CalcHosts;

    partial struct Calcs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Neq<T> neq<T>()
            where T : unmanaged
                => default(Neq<T>);

        [MethodImpl(Inline), SpanOp, Closures(Closure)]
        public static Span<bit> neq<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b, Span<bit> dst)
            where T : unmanaged
                => gcalc.apply(Calcs.neq<T>(), a, b, dst);
    }
}