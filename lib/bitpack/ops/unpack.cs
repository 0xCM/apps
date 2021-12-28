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

    partial struct BitPack
    {
        [MethodImpl(Inline), Unpack, Closures(Closure)]
        public static uint unpack<T>(ReadOnlySpan<T> src, Span<bit> dst)
            where T : unmanaged
        {
            var kCell = src.Length;
            var wCell = width<T>(w8);
            var bitcount = width<T>()*kCell;
            ref var target = ref first(dst);
            var k = 0;
            for(var i=0; i<kCell; i++)
            for(byte bitpos=0; bitpos<wCell; bitpos++, k++)
                seek(target, k) = bit.gtest(skip(src, i), bitpos);
            return bitcount;
        }

        [Unpack, Closures(Closure)]
        public static Span<bit> unpack<T>(T src)
            where T : unmanaged
        {
            var count = width<T>(w8);
            var dst = span<bit>(count);
            for(byte i=0; i<count; i++)
                seek(dst,i) = bit.gtest(src,i);
            return dst;
        }

        /// <summary>
        /// Projects each source bit from each source element into an element of the target span at the corresponding index
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        /// <typeparam name="T">The bit source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Span<T> unpack<S,T>(ReadOnlySpan<S> src, Span<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            if(typeof(T) == typeof(bit))
            {
                var target = recover<T,bit>(dst);
                unpack(src, target);
                return recover<bit,T>(target);
            }
            else
            {
                var wCell = width<S>(w32);
                var cells = (uint)src.Length;
                var wSource = wCell*(uint)cells;
                var k = 0u;
                for(var i=0; i<cells; i++)
                for(byte j=0; j<wCell; j++)
                    seek(dst, k++) = bit.gtest(skip(src,i), j) == bit.On ? one<T>() : zero<T>();
                return dst;
            }
        }

        [MethodImpl(Inline)]
        public static void unpack<S,T>(S src, Span<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            var count = min(width<S>(), dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst, i) = bit.gtest(src, (byte)i) == bit.On ? one<T>() : zero<T>();
        }

        public static Span<T> unpack<S,T>(Span<S> src, Span<T> dst)
            where S : unmanaged
            where T : unmanaged
                => unpack(src.ReadOnly(), dst);

        [Unpack, Closures(Closure)]
        public static Span<bit> unpack<T>(ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var dst = alloc<bit>(width<T>()*src.Length);
            unpack(src, dst);
            return dst;
        }

        /// <summary>
        /// Unpacks a specified number source bytes to a corresponding count of 32-bit target values
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bytes to pack</param>
        /// <param name="dst">The target reference, of size at least 256*count bits</param>
        [MethodImpl(Inline), Op]
        public static void unpack(in byte src, int count, ref uint dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            for(var i=0; i<count; i++)
            {
                unpack1x8(skip(src, i), ref tmp);
                vpack.vinflate8x256x32u(tmp).StoreTo(ref seek(dst, i*8));
            }
        }

        /// <summary>
        /// Unpacks a specified number source bytes to a corresponding count of 256-bit blocks comprising 32-bit target values
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="blocks">The number of bytes to pack</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack(in byte src, int blocks, in SpanBlock256<uint> dst)
            => unpack(src, blocks, ref dst.First);
    }
}