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

    partial class bits
    {
        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static byte set(byte src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static sbyte set(sbyte src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static ushort set(ushort src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static short set(short src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static uint set(uint src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static int set(int src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static ulong set(ulong src, byte index, bit state)
            => bit.set(src, index, state);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static long set(long src, byte index, bit state)
            => bit.set(src, index, state);


        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The source bit index</param>
        /// <param name="value">The state with which to align a source bit</param>
        [MethodImpl(Inline), SetBit]
        public static ref byte set(ref byte src, byte pos, bit state)
        {
            var c = ~u8(state) + 1;
            src ^= (byte)((c ^ src) & (1 << pos));
            return ref src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The source bit index</param>
        /// <param name="value">The state with which to align a source bit</param>
        [MethodImpl(Inline), SetBit]
        public static ref ushort set(ref ushort src, byte pos, bit state)
        {
            var c = ~u16(state) + 1;
            src ^= (ushort)((c ^ src) & (1 << pos));
            return ref src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The source bit index</param>
        /// <param name="value">The state with which to align a source bit</param>
        [MethodImpl(Inline), SetBit]
        public static ref uint set(ref uint src, byte pos, bit state)
        {
            var c = ~u32(state) + 1u;
            src ^= (uint)((c ^ src) & (1u << pos));
            return ref src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The source bit index</param>
        /// <param name="value">The state with which to align a source bit</param>
        [MethodImpl(Inline), SetBit]
        public static ref ulong set(ref ulong src, byte pos, bit state)
        {
            var c = ~u64(state) + 1ul;
            src ^= (c ^ src) & (1ul << pos);
            return ref src;
        }

    }
}