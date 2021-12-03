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

    partial struct LookupTables
    {
        /// <summary>
        /// Returns a reference to a coordiate-identified cell from a linear sequence that
        /// defines a table with row-major order
        /// </summary>
        /// <param name="dim"></param>
        /// <param name="key"></param>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(GridDim<ushort> dim, LookupKey key, Span<T> src)
        {
            var i = offset(dim, key.Row(), key.Col());
            return ref seek(src,i);
        }
    }
}