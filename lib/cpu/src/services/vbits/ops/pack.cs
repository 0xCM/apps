//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static BitMasks;
    using static BitMaskLiterals;
    using static Numeric;
    using static Root;
    using static core;

    partial struct vbits
    {
        /// <summary>
        /// Packs 4 1-bit values taken from the least significant bit of each source byte of an index-identified block
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mod">The bit selection modulus</param>
        /// <param name="block">The index of the block to pack</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte pack4x8x1<T>(in SpanBlock32<T> src, int block)
            where T : unmanaged
                => (byte)gather(uint32(src.BlockLead(block)), Lsb32x8x1);

        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        [MethodImpl(Inline), Op]
        static byte pack8(ulong src)
            => (byte)gather(src, Lsb64x8x1);

        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte pack8x8x1<T>(in T src)
            where T : unmanaged
                => (byte)gather(force<T,ulong>(src), Lsb64x8x1);

        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        /// <param name="mod">The selection modulus</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte pack8x8x1<T>(ReadOnlySpan<T> src, uint offset)
            where T : unmanaged
                => pack8(uint64(skip(src,(uint)offset)));

        /// <summary>
        /// Packs 8 1-bit values taken from the least significant bit of each source byte of an index-identified block
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mod">The bit selection modulus</param>
        /// <param name="block">The index of the block to pack</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte pack8x8x1<T>(in SpanBlock64<T> src, uint block)
            where T : unmanaged
                => pack8(force<T,ulong>(src.BlockLead((int)block)));

        /// <summary>
        /// Packs 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="n">The number of bits to pack</param>
        /// <param name="mod">The bit selection modulus</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(in T src)
            where T : unmanaged
                => cpu.vmovemask(gcpu.v8u(gcpu.vsll(cpu.vload(w128, view64u(src)),7)));

        /// <summary>
        /// Pack 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The pack source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(in SpanBlock128<T> src, uint block = 0)
            where T : unmanaged
                => pack16x8x1(src.BlockLead((int)block));

        /// <summary>
        /// Pack 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        /// <param name="mod">The selection modulus</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(ReadOnlySpan<T> src, uint offset = 0)
            where T : unmanaged
                => pack16x8x1(skip(src,(uint)offset));

        /// <summary>
        /// Packs 64 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong pack64x8x1<T>(in T src)
            where T : unmanaged
        {
            var dst = 0ul;
            dst = (ulong)vbits.pack32x8x1(src);
            dst |=(ulong)vbits.pack32x8x1(skip(src, 32)) << 32;
            return dst;
        }

        /// <summary>
        /// Packs 64 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong pack64x8x1<T>(in SpanBlock512<T> src, uint block)
            where T : unmanaged
                => pack64x8x1(src.BlockLead((int)block));

        /// <summary>
        /// Packs 64 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong pack64x8x1<T>(ReadOnlySpan<T> src, uint offset)
            where T : unmanaged
                => pack64x8x1(skip(src, offset));

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static T pack32x1<T>(Span<uint> src)
        //     where T : unmanaged
        //         => pack32x1_u<T>(src);

        // [MethodImpl(Inline)]
        // static T pack32x1_u<T>(Span<uint> src)
        //     where T : unmanaged
        // {
        //     if(typeof(T) == typeof(byte))
        //         return convert<T>(BitPack.pack1x8(src));
        //     else if(typeof(T) == typeof(ushort))
        //         return convert<T>(BitPack.pack1x16(src));
        //     else if(typeof(T) == typeof(uint))
        //         return convert<T>(BitPack.pack1x32(src));
        //     else if(typeof(T) == typeof(ulong))
        //         return convert<T>(BitPack.pack1x64(src));
        //     else
        //         return pack32x1_i<T>(src);
        // }

        // [MethodImpl(Inline)]
        // static T pack32x1_i<T>(Span<uint> src)
        //     where T : unmanaged
        // {
        //     if(typeof(T) == typeof(sbyte))
        //         return convert<T>(BitPack.pack1x8(src));
        //     else if(typeof(T) == typeof(short))
        //         return convert<T>(BitPack.pack1x16(src));
        //     else if(typeof(T) == typeof(int))
        //         return convert<T>(BitPack.pack1x32(src));
        //     else if(typeof(T) == typeof(long))
        //         return convert<T>(BitPack.pack1x64(src));
        //     else
        //         throw no<T>();
        // }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T pack<T>(ReadOnlySpan<byte> src, uint offset, out T dst)
            where T : unmanaged
        {
            dst = default;
            var buffer = bytes(dst);
            pack(src, offset, ref first(buffer));
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static void pack(ReadOnlySpan<byte> src, uint offset, ref byte dst)
        {
            const byte M = 8;
            var count = src.Length;
            var kIn = (uint)(count - offset);
            var kOut = kIn/M + (kIn % M == 0 ? 0 : 1);
            for(int i=0, j=0; j<kOut; i+=M, j++)
            {
                ref var b = ref seek(dst, j);
                for(var k=0; k<M; k++)
                {
                    var srcIx = i + k + offset;
                    if(srcIx < kIn && skip(src, srcIx) != 0)
                        b |= (byte)(1 << k);
                }
            }
        }

        /// <summary>
        /// Packs bitsize[T] values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mod">The bit selection modulus</param>
        /// <param name="offset">The source offset</param>
        /// <param name="t">A target type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T pack<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
            where S : unmanaged
            where T : unmanaged
                => pack_u<S,T>(src, mod, offset);

        /// <summary>
        /// Packs bitsize[T] values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mod">The bit selection modulus</param>
        /// <param name="offset">The source offset</param>
        /// <param name="t">A target type representative</param>
        /// <typeparam name="S">The source cell type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T pack<S,T>(Span<S> src, N8 mod, uint offset)
            where S : unmanaged
            where T : unmanaged
                => pack_u<S,T>(src.ReadOnly(), mod, offset);

        [MethodImpl(Inline)]
        static T pack_u<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
            where S : unmanaged
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(pack8x8x1(src, offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(pack16x8x1(src, offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vbits.pack32x8x1(src, offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(pack64x8x1(src, offset));
            else
                return pack_i<S,T>(src, mod, offset);
        }

        [MethodImpl(Inline)]
        static T pack_i<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
            where S : unmanaged
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>((sbyte)pack8x8x1(src, offset));
            else if(typeof(T) == typeof(short))
                return generic<T>((short)pack16x8x1(src, offset));
            else if(typeof(T) == typeof(int))
                return generic<T>((int)vbits.pack32x8x1(src, offset));
            else if(typeof(T) == typeof(long))
                return generic<T>((long)pack64x8x1(src, offset));
            else
                throw no<T>();
        }
    }
}