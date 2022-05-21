//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static bits;
    using static BitMasks;

    partial class PolyBits
    {
        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<byte> dst)
            => unpack1x8(src, ref first(dst));

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<bit> dst)
            => unpack1x8(src, ref u8(first(dst)));

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of 8 corresponding target bytes
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">A reference to the target buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack1x8(byte src, ref byte dst)
        {
            seek64(dst, 0) = scatter(src, lsb<ulong>(n8,n1));
            return ref dst;
        }

        /// <summary>
        /// Distributes the first 4 source bits acros 4 segments, each of effective width of 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x1(byte src, Span<bit> dst)
            => first(recover<bit,uint>(dst)) = scatter((uint)src, lsb<uint>(n8, n1));

        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<byte> dst)
        {
            var mask = BitMasks.lsb<ulong>(n8, n1);
            ref var lead = ref first(dst);
            seek64(lead, 0) = scatter((ulong)(byte)src, mask);
            seek64(lead, 1) = scatter((ulong)((byte)(src >> 8)), mask);
        }

        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<bit> dst)
            => unpack16x1(src, recover<bit,byte>(dst));
    }
}