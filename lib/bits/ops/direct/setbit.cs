//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

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
        public static byte setbit(byte src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static sbyte setbit(sbyte src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static ushort setbit(ushort src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static short setbit(short src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static uint setbit(uint src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static int setbit(int src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static ulong setbit(ulong src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);

        /// <summary>
        /// Sets a source bit to a specified state
        /// </summary>
        /// <param name="src">The source segment</param>
        /// <param name="index">The bit position</param>
        /// <param name="state">The value to be applied</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), SetBit]
        public static long setbit(long src, byte index, bit state)
            => state ? enable(src, index) : disable(src, index);
    }
}