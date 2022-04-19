//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static core;
    using static cpu;

    partial struct Bitfields
    {
        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each 8-bit source segment
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte pack8x1(ulong src)
            => (byte)bits.gather(src, Lsb64x8x1);

        /// <summary>
        /// Packs 4 1-bit values taken from the least significant bit of each 8-bit source segment
        /// </summary>
        [MethodImpl(Inline), Op]
        public static byte pack4x1(uint src)
            => (byte)bits.gather(src, Lsb32x8x1);

        /// <summary>
        /// Packs the the leading source bits from 8 32-bit integers into a single 8-bit segment
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target value</param>
        [MethodImpl(Inline), Op]
        public static byte pack8x1(ReadOnlySpan<uint> src)
        {
            var v0 = vload(w256, first(src));
            return (byte)vpack.vpacklsb(vpack.vpack128x8u(v0));
        }

        /// <summary>
        /// Partitions a 64-bit source value into 64 individual bit values
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static void pack64x1(ulong src, Span<bit> dst)
            => BitPack.pack64x1(src, dst);

        [MethodImpl(Inline), Op]
        public static ref byte pack4x2(byte a, byte b, ref byte dst)
        {
            dst = (byte)((a & 0xF) | (b >> 4));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x3(byte a0, byte a1, byte a2, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack4x4(byte a0, byte a1, byte a2, byte a3, ref ushort dst)
        {
            dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8)  | ((a3 & 0xF000) >> 12));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort pack8x2(ushort a, ushort b, ref ushort dst)
        {
            dst = (ushort)((a & 0xFF) | (b >> 8));
            return ref dst;
        }
    }
}