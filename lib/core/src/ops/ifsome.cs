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
        /// <summary>
        /// Invokes an action if the supplied value is not null
        /// </summary>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="x">The potentially null value</param>
        /// <param name="f">The action to invoke if possible</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void ifsome<T>(T x, Action<T> f)
            where T : class
        {
            if(x != null)
                f(x);
        }

        /// <summary>
        /// Invokes an action if the supplied value is not null
        /// </summary>
        /// <typeparam name="V">The value type</typeparam>
        /// <param name="x">The potentially null value</param>
        /// <param name="f">The action to invoke if possible</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void ifsome<T>(T? x, Action<T> f)
            where T : struct
        {
            if(x.HasValue)
                f(x.Value);
        }
    }
}