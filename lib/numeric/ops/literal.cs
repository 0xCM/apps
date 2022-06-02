//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Numeric
    {
        // [MethodImpl(Inline), Op]
        // public static NumericLiteral literal(NumericBaseKind @base, string name, object value, string text)
        //     => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static NumericLiteral<T> literal<T>(NumericBaseKind @base, string Name, T data, string Text)
        //     where T : unmanaged
        //         => new NumericLiteral<T>(Name,data, Text, @base);
        [Op]
        public static NumericLiteral literal(Base2 @base, string name, object value, string text)
            => new NumericLiteral(@base, name, value ?? 0u, text ?? EmptyString);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static NumericLiteral<T> literal<T>(Base2 @base, string Name, T Value, string text)
        //     where T : unmanaged
        //         => new NumericLiteral<T>(Name, Value, text, @base);

        // [MethodImpl(Inline), Op]
        // public static NumericLiteral literal(Base10 @base, string Name, object Value, string text)
        //     => new NumericLiteral(@base,Name, Value, text);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static NumericLiteral<T> literal<T>(Base10 @base, string Name, T data, string text)
        //     where T : unmanaged
        //         => new NumericLiteral<T>(Name, data, text, @base);

        // [MethodImpl(Inline), Op]
        // public static NumericLiteral literal(Base16 @base, string name, object value, string text)
        //     => new NumericLiteral(@base,name, value, text);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static NumericLiteral<T> literal<T>(Base16 b,  string Name, T data, string Text)
        //     where T : unmanaged
        //         => new NumericLiteral<T>(Name, data, Text, b);
    }
}