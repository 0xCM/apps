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

    partial struct vbits
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
    }
}