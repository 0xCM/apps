//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Widths
    {
        /// <summary>
        /// Computes the bit-width of a parametrically-identified type, returning the result as a <see cref='BitWidth'/> value
        /// </summary>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        internal static ulong size<T>()
            => (ulong)Unsafe.SizeOf<T>();
    }
}