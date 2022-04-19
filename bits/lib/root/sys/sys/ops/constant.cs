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
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T constant<T>(FieldInfo src)
            => proxy.constant<T>(src);

        [MethodImpl(Options), Op]
        public static object constant(FieldInfo src)
            => proxy.constant(src);
    }
}