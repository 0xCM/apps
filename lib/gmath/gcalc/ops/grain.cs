//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct gcalc
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T grain<T>(in ClosedInterval<T> src, ulong width = 100ul)
            where T : unmanaged, IEquatable<T>, IComparable<T>
                => generic<T>(src.Width/core.min(src.Width, width));
    }
}