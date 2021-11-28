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

    using C = AsciCode;

    partial struct Cmd
    {
        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from a specified asci character
        /// </summary>
        /// <param name="c0">The delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(char c0)
            => new ArgPrefix((C)c0);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from a specified asci code
        /// </summary>
        /// <param name="c0">The delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(C c0)
            => new ArgPrefix(c0);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from two specified characters
        /// </summary>
        /// <param name="c0">The first part of the delimiter</param>
        /// <param name="c1">The second part of the delimiter</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(char c0, char c1)
            => new ArgPrefix((C)c0, (C)c1);

        /// <summary>
        /// Defines an <see cref='ArgPrefix'/> from two specified asci codes
        /// </summary>
        /// <param name="c0">The first part of the prefix</param>
        /// <param name="c1">The second part of the prefix</param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(C c0, C c1)
            => new ArgPrefix((C)c0, (C)c1);

        /// <summary>
        /// Creates a <see cref='ArgPrefix'/> from the leading source element(s)
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(string src)
            => prefix(chars(src));

        /// <summary>
        /// Creates a <see cref='ArgPrefix'/> from the leading source element(s)
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            if(count == 0)
                return ArgPrefix.Empty;
            else if(count == 1)
                return new ArgPrefix((C)skip(src, 0));
            else
                return new ArgPrefix((C)skip(src, 0), (C)skip(src, 1));
        }
    }
}