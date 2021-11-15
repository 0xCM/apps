//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
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