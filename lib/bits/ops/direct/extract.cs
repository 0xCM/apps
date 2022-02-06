//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    partial class bits
    {
        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static sbyte extract(sbyte src, byte min, byte max)
            => (sbyte)Bmi1.BitFieldExtract((uint)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static byte extract(byte src, byte min, byte max)
            => (byte)Bmi1.BitFieldExtract((uint)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static short extract(short src, byte min, byte max)
            => (short)Bmi1.BitFieldExtract((uint)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static ushort extract(ushort src, byte min, byte max)
            => (ushort)Bmi1.BitFieldExtract((uint)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static uint extract(uint src, byte min, byte max)
            => Bmi1.BitFieldExtract(src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static int extract(int src, byte min, byte max)
            => (int)Bmi1.BitFieldExtract((uint)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static ulong extract(ulong src, byte min, byte max)
            => Bmi1.X64.BitFieldExtract(src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static long segment(long src, byte min, byte max)
            => (long)Bmi1.X64.BitFieldExtract((ulong)src, min, (byte)(max - min + 1));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static float extract(float src, byte min, byte max)
            => BitConverter.Int32BitsToSingle(extract(BitConverter.SingleToInt32Bits(src), min, max));

        /// <summary>
        /// Extracts a contiguous range of bits from the source inclusively between two index positions
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="min">The bit position within the source where extraction should begin</param>
        /// <param name="max">The bit position within the source where extraction should end</param>
        [MethodImpl(Inline), BitSeg]
        public static double extract(double src, byte min, byte max)
            => BitConverter.Int64BitsToDouble(segment(BitConverter.DoubleToInt64Bits(src), min, max));
    }
}