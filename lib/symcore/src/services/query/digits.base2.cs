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
        /// Determines whether an asci span segment defines a sequence of binary digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bit digits(Base2 @base, ReadOnlySpan<C> src, uint offset, uint count)
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
        /// Determines whether a character span segment defines a sequence of binary digits
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <param name="count">The sequence length</param>
        [MethodImpl(Inline), Op]
        public static bit digits(Base2 @base, ReadOnlySpan<char> src, uint offset, uint count)
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
        /// Counts the number of contiguous binary digits begining at a specified offset
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The search offset</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base2 @base, ReadOnlySpan<C> src, uint offset)
        {
            var limit = src.Length - offset;
            var counter = 0u;
            for(var i=offset; i<limit; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    break;
                counter++;
            }

            return counter;
        }

        /// <summary>
        /// Counts the number of contiguous binary digits begining at a specified offset
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The search offset</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src, uint offset)
        {
            var limit = src.Length - offset;
            var counter = 0u;
            for(var i=offset; i<limit; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    break;
                counter++;
            }

            return counter;
        }
    }
}