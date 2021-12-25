//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics.X86;

    using static Root;

    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static sbyte extract(sbyte src, byte k0, byte k1)
            => (sbyte)Bmi1.BitFieldExtract((uint)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static byte extract(byte src, byte k0, byte k1)
            => (byte)Bmi1.BitFieldExtract((uint)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static short extract(short src, byte k0, byte k1)
            => (short)Bmi1.BitFieldExtract((uint)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static ushort extract(ushort src, byte k0, byte k1)
            => (ushort)Bmi1.BitFieldExtract((uint)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static uint extract(uint src, byte k0, byte k1)
            => Bmi1.BitFieldExtract(src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static int extract(int src, byte k0, byte k1)
            => (int)Bmi1.BitFieldExtract((uint)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static ulong extract(ulong src, byte k0, byte k1)
            => Bmi1.X64.BitFieldExtract(src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static long segment(long src, byte k0, byte k1)
            => (long)Bmi1.X64.BitFieldExtract((ulong)src, k0, (byte)(k1 - k0 + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static float extract(float src, byte k0, byte k1)
            => BitConverter.Int32BitsToSingle(extract(BitConverter.SingleToInt32Bits(src), k0, k1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="k0">The bit position within the source where extraction should begin</param>
        /// <param name="k1">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static double extract(double src, byte k0, byte k1)
            => BitConverter.Int64BitsToDouble(segment(BitConverter.DoubleToInt64Bits(src), k0, k1));
    }
}