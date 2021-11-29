//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Intervals
    {
        /// <summary>
        /// Defines the unit interval over a parametric domain
        /// </summary>
        /// <param name="t">A representative used only for type inference</param>
        /// <typeparam name="T">The interval domain</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static U01<T> unit<T>()
            where T : unmanaged
                => default;
    }
}