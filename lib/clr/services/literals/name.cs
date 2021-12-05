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

    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static StringAddress name(FieldInfo src)
            => strings.address(src.Name);

        [MethodImpl(Inline), Op]
        public static StringAddress name(Type src)
            => strings.address(src.Name);

        [MethodImpl(Inline), Op]
        public static StringAddress name(PropertyInfo src)
            => strings.address(src.Name);

        [MethodImpl(Inline), Op]
        public static StringAddress name(MethodBase src)
            => strings.address(src.Name);
    }
}