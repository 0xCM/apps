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
        public static string trim(string src)
            => empty(src) ? EmptyString : src.Trim();

        [MethodImpl(Inline), Op]
        public static string trim(string src, char match)
            => empty(src) ? EmptyString : src.Trim(match);

        [MethodImpl(Inline), Op]
        public static string trim(string src, char[] matches)
            => empty(src) ? EmptyString : src.Trim(matches);

        [Op]
        public static string[] trim(string[] src)
            => src.Select(s => s.Trim());

        [Op]
        public static string[] trim(string[] src, char match)
            => src.Select(s => s.Trim(match));

        [Op]
        public static string[] trim(string[] src, char[] matches)
            => src.Select(s => s.Trim(matches));
    }
}