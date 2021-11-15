//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    partial class XText
    {
        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, string match)
        {
            var idx = src.LastIndexOf(match);
            if (idx != -1)
                return src.Substring(idx + match.Length);
            else
                return string.Empty;
        }

        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, char match)
        {
            var idx = src.LastIndexOf(match);
            if (idx != -1 && idx < src.Length - 1)
                return src.Substring(idx + 1);
            else
                return EmptyString;
        }
    }
}