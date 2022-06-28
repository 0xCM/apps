//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    using O = ApiOpaqueClass;

    partial struct sys
    {
        [MethodImpl(Options), Opaque(O.GetFieldValue)]
        public static object value(object src, FieldInfo field)
            => proxy.value(src,field);

        [MethodImpl(Options), Opaque(O.GetGenericType), Closures(Closure)]
        public static T value<T>(object src, FieldInfo field)
            => proxy.value<T>(src,field);
    }
}