//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LimitValues;
    using static BitMasks;

    partial class bits
    {
        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static sbyte enable(sbyte src, byte pos)
            => src |= (sbyte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static byte enable(byte src, byte pos)
            => src |= (byte)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static short enable(short src, byte pos)
            => src |= (short)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static ushort enable(ushort src, byte pos)
            => src |= (ushort)(1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static int enable(int src, byte pos)
            => src |= (1 << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static uint enable(uint src, byte pos)
            =>  src |= (1u << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static long enable(long src, byte pos)
            => src |= (1L << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static ulong enable(ulong src, byte pos)
            => src |= (1ul << pos);

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static float enable(float src, byte pos)
        {
            var srcBits = BitConverter.SingleToInt32Bits(src);
            srcBits |= 1 << pos;
            src = BitConverter.Int32BitsToSingle(srcBits);
            return src;
        }

        /// <summary>
        /// Enables a specified source bit
        /// </summary>
        /// <param name="src">The source value to manipulate</param>
        /// <param name="pos">The position of the bit to enable</param>
        [MethodImpl(Inline), Enable]
        public static double enable(double src, byte pos)
        {
            var srcBits = BitConverter.DoubleToInt64Bits(src);
            srcBits |= 1L << pos;
            src = BitConverter.Int64BitsToDouble(srcBits);
            return src;
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static byte enable(byte src, byte index, byte count)
        {
            var mask = (uint)Max16u ^ ((uint)lo64(count - 1) << index);
            return (byte)(~(mask | src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static sbyte enable(sbyte src, byte index, byte count)
        {
            var mask = (int)Max16u ^ ((int)lo64(count - 1) << index);
            return (sbyte)(~(mask | (int)src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static ushort enable(ushort src, byte index, byte count)
        {
            var mask = (uint)Max16u ^ ((uint)lo64(count - 1) << index);
            return (ushort)(~(mask | src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin clearing bits</param>
        /// <param name="count">The number of bits to clear</param>
        [MethodImpl(Inline), Enable]
        public static short enable(short src, byte index, byte count)
        {
            var mask = (int)Max16u ^ ((int)lo64(count - 1) << index);
            return (short)(~(mask | (int)src));
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static uint enable(uint src, byte index, byte count)
        {
            var mask = Max32u ^ ((uint)lo64(count - 1) << index);
            return ~(mask | src);
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static int enable(int src, byte index, byte count)
            => (int)enable((uint)src, index, count);

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static ulong enable(ulong src, byte index, byte count)
        {
            var mask = Max64u ^ (lo64(count - 1) << index);
            return ~(mask | src);
        }

        /// <summary>
        /// Enables a contiguous sequence of source bits starting at a specified index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="index">The index at which to begin</param>
        /// <param name="count">The number of bits to fill</param>
        [MethodImpl(Inline), Enable]
        public static long enable(long src, byte index, byte count)
            => (long)enable((ulong)src, index, count);
    }
}