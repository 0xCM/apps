//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    using static Spans;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(ReadOnlySpan<char> src, char match)
            => length(src) != 0 && first(src) == match;

        /// <summary>
        /// Returns true if the source begins with a specified substring
        /// </summary>
        /// <param name="src">The input</param>
        /// <param name="match">The substring to match</param>
        [MethodImpl(Inline), Op]
        public static bool begins(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
            => length(src) != 0 && src.StartsWith(match);
    }
}