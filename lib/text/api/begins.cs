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

    partial class text
    {
        /// <summary>
        /// Returns true if the source begins with a specified character
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The character to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(string src, char match)
            => length(src) != 0 && @char(src) == match;

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(string src, string match)
            => length(src) != 0 && src.StartsWith(match);
    }
}