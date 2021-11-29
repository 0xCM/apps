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
        /// Returns the number of asci character codes that precede a null-terminator, if any; otherwise returns the lenght of the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<C> src)
        {
            var counter = 0u;
            var max = (uint)src.Length;

            if(max == 0)
                return 0;

            for(var i=0u; i<max; i++)
                if(skip(src,i) == 0)
                    return i;
            return max;
        }

        /// <summary>
        /// Returns the number of characters that precede a null-terminator, if any; otherwise returns the lenght of the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<char> src)
        {
            var counter = 0u;
            var max = (uint)src.Length;

            if(max == 0)
                return 0;

            for(var i=0u; i<max; i++)
                if(skip(src,i) == 0)
                    return i;
            return max;
        }
    }
}