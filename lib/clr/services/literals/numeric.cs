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
    using static core;

    using NBK = NumericBaseKind;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> numeric<T>(string Name, T data, string Text, NBK @base)
            where T : unmanaged
                => new NumericLiteral<T>(Name,data, Text, @base);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T numeric<T>(FieldInfo f)
            where T : unmanaged
                => sys.constant<T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] numeric<T>(Type src)
            where T : unmanaged
                => map(search<T>(src),numeric<T>);
    }
}