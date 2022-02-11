//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class text
    {
        /// <summary>
        /// Returns the text right of, but not including, a specified index; or empty if invalid index is provided
        /// </summary>
        /// <param name="src"></param>
        /// <param name="index"></param>
        [MethodImpl(Inline), Op]
        public static string right(string src, int index)
        {
            if(empty(src) || index < 0)
                return EmptyString;

            var length = src.Length;
            if(length == 0)
                return EmptyString;

            if(index < length - 1)
                return slice(src, index + 1);
            else
                return EmptyString;
        }

        [Op]
        public static string right(string src, char match)
        {
            var i = index(src,match);
            if(i>0)
                return right(src,i);
            else
                return EmptyString;
        }

        [Op]
        public static string right(string src, string match)
        {
            var i = index(src, match);
            if(i>0)
                return right(src, i + match.Length - 1);
            else
                return EmptyString;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> right(ReadOnlySpan<char> src, string match)
        {
            var i = text.index(src,match);
            if(i > 0)
                return right(src,i + match.Length - 1);
            else
                return default;
        }


        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> right(ReadOnlySpan<char> src, int index)
        {
            if(index < src.Length - 1)
                return core.slice(src, index + 1);
            else
                return default;
        }
    }
}