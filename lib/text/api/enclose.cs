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
        /// Encloses a value with a fence
        /// </summary>
        /// <param name="src"></param>
        /// <param name="boundary"></param>
        /// <typeparam name="T"></typeparam>
        public static string enclose<T>(T src, Fence<char> boundary)
            => string.Format("{0}{1}{2}",boundary.Left, src, boundary.Right);

        /// <summary>
        /// Encloses text within a bounding string
        /// </summary>
        /// <param name="content">The text to enclose</param>
        /// <param name="sep">The left and right boundary</param>
        [MethodImpl(Inline), Op]
        public static string enclose(object content, string sep)
            => string.Concat(sep,$"{content}",sep);
   }
}