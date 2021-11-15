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
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> after(ReadOnlySpan<char> src, char match)
        {
            var i =  src.IndexOf(match);
            return i != NotFound ? core.slice(src,i + 1) : default;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> after(ReadOnlySpan<char> src, ReadOnlySpan<char> match)
        {
            var i = src.IndexOf(match);
            return i != NotFound ? core.slice(src, i + match.Length) : default;
        }

        [Op]
        public static bool after(string src, string match, out string result)
        {
            var i = src.IndexOf(match);
            result = i == NotFound ? EmptyString : RP.substring(src, i + match.Length);
            return i != NotFound;
        }
    }
}