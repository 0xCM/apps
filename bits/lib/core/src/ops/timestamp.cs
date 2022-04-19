//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
        [MethodImpl(Inline), Op]
        public static Timestamp timestamp()
            => now();

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(ulong ticks)
            => new Timestamp(ticks);

        [MethodImpl(Inline), Op]
        public static Timestamp timestamp(long ticks)
            => new Timestamp((ulong)ticks);
    }
}