//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static Root;
    using static core;

    partial class text
    {
        [Op, Closures(Closure)]
        public static string delimit<T>(T[] src, char delimiter)
            => delimit(@readonly(src), delimiter);

        [Op, Closures(Closure)]
        public static string delimit<T>(IEnumerable<T> src, char delimiter)
            => string.Join($"{delimiter} ", src);

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char delimiter, int pad)
            => delimit(src, delimiter, pad, true);

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char delimiter, int pad, bool space)
        {
            var dst = buffer();
            var count = src.Length;
            var slot = RP.pad(pad);
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.AppendFormat(slot, skip(src,i));
                if(i != last)
                {
                    dst.Append(delimiter);
                    if(space)
                        dst.Append(Chars.Space);
                }
            }
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(ReadOnlySpan<T> src, char delimiter)
        {
            var dst = buffer();
            var count = src.Length;
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.AppendItem(skip(src,i));

                if(i != last)
                {
                    dst.Append(delimiter);
                    dst.Append(Chars.Space);
                }

            }
            return dst.ToString();
        }

        [Op, Closures(Closure)]
        public static string delimit<T>(IEnumerable<T> src, char delimiter, int pad)
            => delimit(src.ToSpan().ReadOnly(), delimiter, pad);
    }
}