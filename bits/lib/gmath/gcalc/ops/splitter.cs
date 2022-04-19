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
        public static SeqSplitter<T> splitter<T>(T delimiter)
            where T : unmanaged
                => new SeqSplitter<T>(delimiter);
    }
}