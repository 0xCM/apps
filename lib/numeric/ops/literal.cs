//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using NBK = NumericBaseKind;

    partial struct Numeric
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T one<T>()
            where T : unmanaged
                => force<T>(1);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(string Name, object Value, string Text, NBK @base)
            => new NumericLiteral(Name,Value,Text, @base);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(string Name, T data, string Text, NBK @base)
            where T : unmanaged
                => new NumericLiteral<T>(Name,data, Text, @base);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(Base2 b, string Name, object Value, string Text)
            => new NumericLiteral(Name, Value, Text, NBK.Base2);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base2 b, string Name, T Value, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, Value, Text, NBK.Base2);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(Base10 b, string Name, object Value, string Text)
            => new NumericLiteral(Name, Value, Text, NBK.Base10);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base10 b, string Name, T data, string Text)
            where T : unmanaged
            => new NumericLiteral<T>(Name, data, Text, NBK.Base10);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(Base16 b, string Name, object Value, string Text)
            => new NumericLiteral(Name, Value, Text, NBK.Base16);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base16 b,  string Name, T data, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, data, Text, NBK.Base16);
    }
}