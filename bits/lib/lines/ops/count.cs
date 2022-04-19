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
        /// <summary>
        /// Counts the number of asci-encoded lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<byte> src)
        {
            var size = src.Length;
            var counter = 0u;
            for(var pos=0u; pos<size- 1; pos++)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                    counter++;
            }
            return counter;
        }

        /// <summary>
        /// Counts the number of lines represented in the source
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<char> src)
        {
            var size = src.Length;
            var counter = 0u;
            for(var pos=0u; pos<size- 1; pos++)
            {
                ref readonly var a0 = ref skip(src, pos);
                ref readonly var a1 = ref skip(src, pos + 1);
                if(SQ.eol(a0,a1))
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<AsciCode> src)
            => count(recover<AsciCode,byte>(src));
    }
}