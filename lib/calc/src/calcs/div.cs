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
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Div), Closures(AllNumeric)]
        public static Div<T> div<T>()
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Div, Closures(Closure)]
        public static Span<T> div<T>(ReadOnlySpan<T> l, ReadOnlySpan<T> r, Span<T> dst)
            where T : unmanaged
                => gcalc.apply(Calcs.div<T>(), l, r, dst);
    }
}