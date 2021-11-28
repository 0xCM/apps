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

    partial class BitBlocks
    {
        /// <summary>
        /// Sets a bit value in a T-sequence predicated on a linear index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The linear index of the target bit, relative to the sequence head</param>
        /// <typeparam name="T">The sequence type</typeparam>
        [MethodImpl(Inline), SetBit, Closures(Closure)]
        public static void setbit<T>(in SpanBlock256<T> src, int index, bit value)
            where T : unmanaged
        {
            var loc = bit.bitpos<T>((uint)index);
            src[loc.CellIndex] = gbits.setbit(src[loc.CellIndex], (byte)loc.BitOffset, value);
        }

        /// <summary>
        /// Sets the state of a grid bit identified by its linear position
        /// </summary>
        /// <param name="bitpos">The 0-based linear bit index</param>
        /// <param name="state">The source state</param>
        /// <param name="dst">A reference to the grid storage</param>
        /// <typeparam name="T">The grid storage segment type</typeparam>
        [MethodImpl(Inline)]
        internal static void setbit<X>(uint bitpos, bit state, ref X dst)
            where X : unmanaged
                => cell(ref dst, bitpos) = gbits.setbit(cell(ref dst, bitpos), (byte)(bitpos % width<X>()), state);
    }
}