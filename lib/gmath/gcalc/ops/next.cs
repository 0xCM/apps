//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref Bin<T> next<T>(ref Bin<T> bin)
            where T : unmanaged, IComparable<T>
        {
            inc(ref edit(bin.Counter));
            return ref bin;
        }
    }
}