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

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted to the caller
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<AsciCode> src, Span<AsciCode> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(digit(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous digit sequence from a specified source and writes the elements to a specified target,
        /// and returns the number of digits extracted to the caller
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, Span<char> dst)
        {
            var max = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<max; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(digit(@base,c))
                    seek(dst,counter++) = c;
                else
                    break;
            }
            return counter;
        }

        /// <summary>
        /// Extracts a contiguous sequence of digits from a specified source
        /// </summary>
        /// <param name="n">The maximum number of digits to extract</param>
        /// <param name="base">The mathematical base</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> digits(N16 n, Base10 @base, ReadOnlySpan<AsciCode> src)
        {
            var storage = ByteBlock16.Empty;
            var dst = recover<AsciCode>(storage.Bytes);
            var count = digits(base10, src, dst);
            return count == 0 ? default : slice(dst,0,count);
        }

        /// <summary>
        /// Extracts a contiguous sequence of digits from a specified source
        /// </summary>
        /// <param name="n">The maximum number of digits to extract</param>
        /// <param name="base">The mathematical base</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> digits(N16 n, Base10 @base, ReadOnlySpan<char> src)
        {
            var storage = CharBlock16.Null;
            var dst = storage.Data;
            var count = digits(base10, src, dst);
            return count == 0 ? default : slice(dst,0,count);
        }

        /// <summary>
        /// Determines whether an asci span segment defines a sequence of decimal digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bit digits(Base10 @base, ReadOnlySpan<C> src, uint offset, uint count)
        {
            for(var i=offset; i<count+offset; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether a character span segment defines a sequence of decimal digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bit digits(Base10 @base, ReadOnlySpan<char> src, uint offset, uint count)
        {
            for(var i=offset; i<count+offset; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    return false;
            }
            return true;
        }
    }
}