//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using O = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(O.GetFieldConstant), Closures(Closure)]
        public static T constant<T>(FieldInfo f)
            => (T)f.GetRawConstantValue();

        [MethodImpl(Options), Opaque(O.GetFieldConstant)]
        public static object constant(FieldInfo src)
            => src.GetRawConstantValue();
    }
}