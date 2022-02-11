//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether a code represents a binary digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base2 @base, C src)
            => src == C.d0 || src == C.d1;

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> is a binary digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base2 @base, char src)
            => digit(@base, (C)src);

        /// <summary>
        /// Determines whether a code represents an octal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base8 @base, C src)
            => contains(C.d0, C.d7, src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> is an octal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base8 @base, char src)
            => digit(@base, (C)src);

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base10 @base, C src)
            => contains(C.d0, C.d9, src);

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base10 @base, AsciCharSym src)
            => contains(C.d0, C.d9, (C)src);

        /// <summary>
        /// Determines whether a code represents a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base10 @base, byte src)
            => contains((byte)C.d0, (byte)C.d9, src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> is a decimal digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base10 @base, char src)
            => digit(@base, (C)src);

        /// <summary>
        /// Returns the index of the first <see cref='Base10'/> digit found in the source
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static int digitIndex(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(digit(base10, skip(src, i)))
                    return i;
            return NotFound;
        }

        /// <summary>
        /// Determines whether a code represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, LowerCased @case, C src)
            => lowerhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents a lowercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, LowerCased @case, char src)
            => digit(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, UpperCased @case, C src)
            => upperhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> represents an uppercase hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="case">The case selector</param>
        /// <param name="src">The code to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, UpperCased @case, char src)
            => digit(@base, @case, (C)src);

        /// <summary>
        /// Determines whether a code represents a hex digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, C src)
            => lowerhex(src) || upperhex(src);

        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> is in [0..9 | a..f | A..F]
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit digit(Base16 @base, char src)
            => digit(@base, (C)src);
    }
}