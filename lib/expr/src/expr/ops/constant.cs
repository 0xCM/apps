//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct expr
    {
        /// <summary>
        /// Creates a <see cref='Constant{T}'/>
        /// </summary>
        /// <param name="name">The constant identifier</param>
        /// <typeparam name="T">The constant type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);
    }
}