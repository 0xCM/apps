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
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [Op]
        public static int lastindex(string src, char match)
        {
            if(empty(src))
                return -1;

            return src.LastIndexOf(match);
        }

        [MethodImpl(Inline), Op]
        public static int xedni(ReadOnlySpan<char> src, char match)
        {
            var count = src.Length;
            var result = NotFound;
            for(var i=count-1; i>=0; i--)
            {
                ref readonly var c = ref skip(src,i);
                if(c == match)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [Op]
        public static int lastindex(string src, string match)
        {
            if(empty(src) || empty(match))
                return -1;

            return src.LastIndexOf(match);
        }
    }
}