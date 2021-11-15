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

    using SQ = SymbolicQuery;

    partial struct Lines
    {
        [MethodImpl(Inline), Op]
        public static TextLine line(uint number, string content)
            => new TextLine(number, content);

        /// <summary>
        /// Reads a <see cref='AsciLine'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="counter">The current line count</param>
        /// <param name="pos">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(ReadOnlySpan<AsciCode> src, ref uint number, ref uint i, out AsciLine dst)
        {
            var i0 = i;
            dst = default;
            var max = src.Length;
            var length = 0u;
            while(i++ < max - 1)
            {
                if(SQ.eol(skip(src, i), skip(src, i + 1)))
                {
                    length = i - i0;
                    dst = new AsciLine(++number, i0, slice(src, i0, length));
                    i+=2;
                    break;
                }
            }

            return length;
        }

        /// <summary>
        /// Reads a <see cref='UnicodeLine'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(string src, ref uint number, ref uint i, out UnicodeLine dst)
        {
            var i0 = i;
            dst = UnicodeLine.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                dst = new UnicodeLine(++number, i0, EmptyString);
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = new UnicodeLine(++number, i0, text.slice(src, i0, length));
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }

        /// <summary>
        /// Reads a <see cref='UnicodeLine'/> from the data source
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="number">The current line count</param>
        /// <param name="i">The source-relative offset</param>
        /// <param name="dst">The target</param>
        [Op]
        public static uint line(string src, ref uint number, ref uint i, out AsciLine<byte> dst)
        {
            var i0 = i;
            dst = AsciLine<byte>.Empty;
            var max = src.Length;
            var length = 0u;
            var data = span(src);
            if(empty(src,i))
            {
                i+=2;
            }
            else
            {
                while(i++ < max - 1)
                {
                    if(SQ.eol(skip(data, i), skip(data, i + 1)))
                    {
                        length = i - i0;
                        dst = asci(++number, text.asci(text.slice(src, i0, length)).Storage);
                        i+=2;
                        break;
                    }
                }
            }
            return length;
        }
    }
}