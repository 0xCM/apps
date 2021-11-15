//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        /// <summary>
        /// Encloses text within (possibly distinct) left and right boundaries
        /// </summary>
        /// <param name="content">The text to be surrounded by the left and right delimiters</param>
        /// <param name="left">The left delimiter</param>
        /// <param name="right">The right delimiter</param>
        [MethodImpl(Inline), Op]
        public static string enclose(object content, char left, char right)
            => string.Concat(left, $"{content}", right);

        /// <summary>
        /// Encloses text within (possibly distinct) left and right boundaries
        /// </summary>
        /// <param name="content">The text to be bounded</param>
        /// <param name="left">The text on the left</param>
        /// <param name="right">The text on the right</param>
        [MethodImpl(Inline), Op]
        public static string enclose(object content, string left, string right)
            => string.Concat(left, $"{content}", right);

        /// <summary>
        /// Encloses text within a bounding string
        /// </summary>
        /// <param name="content">The text to enclose</param>
        /// <param name="sep">The left and right boundary</param>
        [MethodImpl(Inline), Op]
        public static string enclose(object content, string sep)
            => string.Concat(sep,$"{content}",sep);

        /// <summary>
        /// Encloses a character within uniform left/right bounding string
        /// </summary>
        /// <param name="content">The character to be surrounded by the left and right delimiters</param>
        /// <param name="sep">The boundary delimiter</param>
        [MethodImpl(Inline), Op]
        public static string enclose(char content, string sep)
            => string.Concat(sep,content,sep);

        /// <summary>
        /// Encloses a character within (possibly distinct) left and right boundaries
        /// </summary>
        /// <param name="content">The character to be bounded</param>
        /// <param name="left">The text on the left</param>
        /// <param name="right">The text on the right</param>
        [MethodImpl(Inline), Op]
        public static string enclose(char content, string left, string right)
            => string.Concat(left, content, right);
    }
}