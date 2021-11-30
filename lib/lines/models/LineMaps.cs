//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LineMaps
    {
        [MethodImpl(Inline)]
        public static LineInterval<T> interval<T>(T id, LineNumber min, LineNumber max)
            => new LineInterval<T>(id,min,max);

        [MethodImpl(Inline)]
        public static LineInterval interval(uint id, LineNumber min, LineNumber max)
            => new LineInterval(id, min,max);

        [MethodImpl(Inline)]
        public static LineMap<T> map<T>(LineInterval<T>[] src)
            => src;
    }
}