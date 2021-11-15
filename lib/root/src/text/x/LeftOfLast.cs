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
        [TextUtility]
        public static string LeftOfLast(this string src, string match)
        {
            var idx = src.LastIndexOf(match);
            if (idx != -1)
                return src.Substring(0, idx);
            else
                return string.Empty;
        }

        /// <summary>
        /// Retrieves the substring that precedes the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string LeftOfLast(this string src, char match)
        {
            var idx = src.LastIndexOf(match);
            if (idx != -1)
                return src.Substring(0, idx);
            else
                return string.Empty;
        }
    }
}