//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class XText
    {
       /// <summary>
        /// Gets the string to the left of, but not including, the first instance of a specified character
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character</param>
        [TextUtility]
        public static string LeftOfFirst(this string src, char match)
            => src.Substring(0, Root.apply(src.IndexOf(match), idx => idx == -1 ? src.Length - 1 : idx));

        /// <summary>
        /// Gets the string to the left of, but not including, a specified substring
        /// </summary>
        /// <param name="s">The string to search</param>
        /// <param name="substring">The substring to match</param>
        [TextUtility]
        public static string LeftOfFirst(this string s, string substring)
        {
            var idx = s.IndexOf(substring);
            if (idx != -1)
                return s.LeftOfIndex(idx);
            else
                return string.Empty;
        }
    }
}