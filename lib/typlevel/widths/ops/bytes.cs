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
        /// Computes the number of bytes occupied by an instance of a parametrically-identified type
        /// </summary>
        /// <typeparam name="T">The measurable type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint bytes<T>()
            =>  (uint)(Unsafe.SizeOf<T>());
    }
}