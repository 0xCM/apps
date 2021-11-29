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
    }
}