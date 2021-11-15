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

    partial class gbits
    {
        /// <summary>
        /// Enables an index-identified source bit
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="pos">The 0-based index of the bit to change</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Enable, Closures(AllNumeric)]
        public static T enable<T>(T src, byte pos)
            where T : unmanaged
        {
            if(size<T>() == 1)
                 return generic<T>(bits.enable(uint8(src), pos));
            else if (size<T>() == 2)
                 return generic<T>(bits.enable(uint16(src), pos));
            else if (size<T>() == 4)
                 return generic<T>(bits.enable(uint32(src), pos));
            else
                 return generic<T>(bits.enable(uint64(src), pos));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T enable<T>(T src, byte index, byte count)
            where T : unmanaged
        {
            if(size<T>() == 1)
                return generic<T>(bits.enable(uint8(src), index, count));
            else if (size<T>() == 2)
                return generic<T>(bits.enable(uint16(src), index, count));
            else if (size<T>() == 4)
                return generic<T>(bits.enable(uint32(src), index, count));
            else
                return generic<T>(bits.enable(uint64(src), index, count));
        }
    }
}