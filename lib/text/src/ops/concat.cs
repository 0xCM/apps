//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string concat(params object[] src)
            => string.Concat(src);

        /// <summary>
        /// Concatenates a sequence of characters with no intervening delimiter
        /// </summary>
        /// <param name="src">The characters to concatenate</param>
        [MethodImpl(Inline), Op]
        public static string concat(IEnumerable<char> src)
            => string.Concat(src);

        /// <summary>
        /// Concatenates a sequence of strings, padding each to a specified width and interspersed with a specified delimiter
        /// </summary>
        /// <param name="src">The text to join</param>
        /// <param name="widths">The corresponding widths</param>
        /// <param name="delimiter">The delimiter to use</param>
        [Op]
        public static string concat(ReadOnlySpan<string> src, ReadOnlySpan<byte> widths, char delimiter = FieldDelimiter)
        {
            var dst = buffer();
            var count = min(src.Length, widths.Length);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref readonly var width = ref skip(widths,i);
                dst.Append(field.PadRight(width));
                if(i != count - 1)
                {
                    dst.Append(delimiter);
                    dst.Append(Chars.Space);
                }
            }
            return dst.ToString();
        }
    }
}