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
        /// Computes the combined length of the source entries
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<string> src)
        {
            var total = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
                total += (uint)skip(src,i).Length;
            return total;
        }

        /// <summary>
        /// Determines the length of a specified <see cref='string'/>
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static int length(string src)
            => src?.Length ?? 0;

        /// <summary>
        /// Computes the number of pointer-identified characters that precede a null-terminator
        /// </summary>
        /// <param name="pSrc">The location of the first character</param>
        [MethodImpl(Inline), Op]
        public static unsafe int length(char* pSrc)
        {
            if(pSrc == null)
                return 0;

            var p = pSrc;
            while(*p != Chars.Null)
                p++;
            return (int)(p - pSrc);
        }

        /// <summary>
        /// Computes the number of pointer-identified (asci) characters that precede a null-terminator
        /// </summary>
        /// <param name="pSrc">The location of the first character</param>
        [MethodImpl(Inline), Op]
        public static unsafe int length(byte* pSrc)
        {
            if(pSrc == null)
                return 0;

            var p = pSrc;
            while(*p != Chars.Null)
                p++;

            return (int)(p - pSrc);
        }
    }
}