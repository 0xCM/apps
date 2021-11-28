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
    using static BitMasks;
    using static cpu;

    partial struct BitPack
    {
        /// <summary>
        /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="n">The number of bits to pack</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static ulong pack1x64(in uint src)
        {
            var buffer = z64;
            return pack1x64(src, ref buffer);
        }

        /// <summary>
        /// Partitions a 64-bit source into 64 8-bit targets, each of effective width 1
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static ref byte pack1x64(ulong src, ref byte dst)
        {
            ref var target = ref seek64(dst,0);
            seek(target, 0) = lsb8x1(src);
            seek(target, 1) = lsb8x1(src >> 8);
            seek(target, 2) = lsb8x1(src >> 16);
            seek(target, 3) = lsb8x1(src >> 24);
            seek(target, 4) = lsb8x1(src >> 32);
            seek(target, 5) = lsb8x1(src >> 40);
            seek(target, 6) = lsb8x1(src >> 48);
            seek(target, 7) = lsb8x1(src >> 56);
            return ref dst;
        }

        /// <summary>
        /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target value</param>
        [MethodImpl(Inline), Op]
        public static ref ulong pack1x64(in uint src, ref ulong dst)
        {
            var w = w256;
            var v0 = vload(w, skip(src, 0*8));
            var v1 = vload(w, skip(src, 1*8));
            var x = vpack.vpack256x16u(v0, v1);
            v0 = vload(w, skip(src,2*8));
            v1 = vload(w, skip(src,3*8));

            var y = vpack.vpack256x16u(v0, v1);
            var packed = (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y));

            v0 = vload(w, skip(src,4*8));
            v1 = vload(w, skip(src,5*8));
            x = vpack.vpack256x16u(v0,v1);

            v0 = vload(w, skip(src,6*8));
            v1 = vload(w, skip(src,7*8));
            y = vpack.vpack256x16u(v0,v1);

            packed |= (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y)) << 32;

            dst = packed;
            return ref dst;
        }

        /// <summary>
        /// Partitions a 64-bit source value into 64 individual bit values
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static void pack1x64(ulong src, Span<bit> dst)
        {
            ref var target = ref first(recover<bit,byte>(dst));
            pack1x64(src, ref target);
        }

        /// <summary>
        /// Packs the least significant bit from 64 source values to a 64-bit target
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static ref ulong pack1x64(in NatSpan<N64,uint> src, ref ulong dst)
        {
            dst = pack1x64(src.First);
            return ref dst;
        }

        /// <summary>
        /// Packs the 64 leading source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static ulong pack1x64(Span<uint> src)
            => pack1x64(first(src));
    }
}