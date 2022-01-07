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
        public static NumericLiteral literal(NBK @base, string name, object value, string text)
            => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(NBK @base, string Name, T data, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name,data, Text, @base);
        [Op]
        public static NumericLiteral literal(Base2 @base, string name, object value, string text)
            => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base2 @base, string Name, T Value, string text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, Value, text, NBK.Base2);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(Base10 @base, string Name, object Value, string text)
            => new NumericLiteral(@base,Name, Value, text);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base10 @base, string Name, T data, string text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, data, text, NBK.Base10);

        [MethodImpl(Inline), Op]
        public static NumericLiteral literal(Base16 @base, string name, object value, string text)
            => new NumericLiteral(@base,name, value, text);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NumericLiteral<T> literal<T>(Base16 b,  string Name, T data, string Text)
            where T : unmanaged
                => new NumericLiteral<T>(Name, data, Text, NBK.Base16);
    }
}