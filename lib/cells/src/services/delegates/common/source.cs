//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Delegates
    {
        /// <summary>
        /// Creates an emitter from a method
        /// </summary>
        /// <param name="src">The source method</param>
        /// <param name="host">The host instance if not static</param>
        /// <typeparam name="T">The emission type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Emitter<T> source<T>(MethodInfo src, object host = null)
            where T : unmanaged
                => create<Emitter<T>>(src, host);
    }
}