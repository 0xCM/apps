//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Computes the number of contiguous base-2 digis in a specified character span
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base2 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    break;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// Computes the number of contiguous base-10 digis in a specified character span
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    break;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// Computes the number of contiguous base-16 digis in a specified character span
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Base16 @base, ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!digit(@base, c))
                    break;
            }
            return counter;
        }
    }
}