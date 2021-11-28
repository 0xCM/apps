//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    [ApiHost]
    public static class PolyBits
    {
        const NumericKind Closure = AllNumeric;

        /// <summary>
        /// Produces an interminable stream of random bits
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<Bit32> BitStream32(this ISource src)
        {
            const int w = 64;
            while(true)
            {
                var data = src.Next<ulong>();
                for(var i=0; i<w; i++)
                    yield return Bit32.test(data,i);
            }
        }

        /// <summary>
        /// Fills a caller-supplied target with random bits
        /// </summary>
        /// <param name="source">The data source</param>
        public static void Fill(this IBoundSource source, Span<bit> dst)
        {
            const int w = 64;
            var pos = -1;
            var last = dst.Length - 1;

            while(pos <= last)
            {
                var data = source.Next<ulong>();

                var i = -1;
                while(++pos <= last && ++i < w)
                    dst[pos] = bit.test(data,(byte)i);
            }
        }

        /// <summary>
        /// Produces an interminable stream of random bits
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<bit> BitStream(this ISource src)
            => bitstream(src);

        /// <summary>
        /// Produces an interminable stream of random bits from a value sequence of parametric type
        /// </summary>
        /// <param name="random">The data source</param>
        public static IEnumerable<T> BitStream<T>(this ISource src)
            where T : unmanaged
                => bitstream<T>(src);

        /// <summary>
        /// Transforms an primal enumerator into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> BitStream<T>(this IEnumerator<T> src)
            where T : struct
                => bitstream(src);

        /// <summary>
        /// Transforms an primal source stream into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> BitStream<T>(this IEnumerable<T> src)
            where T : struct
                => bitstream(src);

        /// <summary>
        /// Produces an interminable stream of <see cref='bit'/> values
        /// </summary>
        /// <param name="random">The value source</param>
        [Op]
        public static IEnumerable<bit> bitstream(ISource src)
        {
            while(true)
            {
                var data = src.Next<ulong>();
                for(byte i=0; i<64; i++)
                    yield return bit.test(data,i);
            }
        }

        /// <summary>
        /// Produces an interminable stream of random values from a numeric domain {0,1}
        /// </summary>
        /// <param name="random">The random source</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [Op, Closures(Closure)]
        public static IEnumerable<T> bitstream<T>(ISource src)
            where T : unmanaged
        {
            while(true)
            {
                var data = src.Next<ulong>();
                for(byte i=0; i<64; i++)
                    yield return Numeric.force<byte,T>((byte)bit.test(data,i));
            }
        }

        /// <summary>
        /// Transforms an primal source stream into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static IEnumerable<bit> bitstream<T>(IEnumerable<T> src)
            where T : struct
                => bitstream<T>(src.GetEnumerator());

        /// <summary>
        /// Transforms an primal enumerator into a bitstream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static IEnumerable<bit> bitstream<T>(IEnumerator<T> src)
            where T : struct
        {
            var buffer = alloc<bit>(size<T>());
            while(src.MoveNext())
            {
                bit.unpack(src.Current, buffer.Clear());
                foreach(var b in buffer)
                    yield return b;
            }
        }
    }
}