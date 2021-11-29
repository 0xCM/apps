//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    partial class XText
    {
        /// <summary>
        /// Removes a substring from the source string if it exists
        /// </summary>
        /// <param name="s">The string to manipulate</param>
        /// <param name="substring">The substring to remove</param>
        [TextUtility]
        public static string Remove(this string s, string substring)
            => s.Replace(substring, EmptyString);
    }
}