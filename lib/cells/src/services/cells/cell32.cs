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

    partial class Cells
    {
        /// <summary>
        /// Creates a <see cref='Cell32'/> from a specified <typeparamref name='T'/> value
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Cell32 cell32<T>(T src)
            where T : unmanaged
                => new Cell32(@as<T,uint>(src));
    }
}