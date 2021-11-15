//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    partial struct sys
    {
        /// <summary>
        /// Creates an untyped delegate
        /// </summary>
        /// <param name="src">The target method</param>
        /// <param name="tDelegate">The delegate type</param>
        /// <param name="host">The host instance if not static</param>
        [MethodImpl(Options), Op]
        public static Delegate @delegate(MethodInfo src, Type tDelegate, object host)
            => proxy.@delegate(src, tDelegate, host);
    }
}