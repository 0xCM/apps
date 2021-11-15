//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    [ApiHost]
    public static class PolyBytes
    {
        /// <summary>
        /// Produces an interminable stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        public static IEnumerable<byte> Bytes(this ISource src)
            => bytes(src);

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        public static IEnumerable<byte> Bytes(this ISource src, int count)
            => bytes(src, count);

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        public static IEnumerable<byte> Bytes(this ISource src, uint count)
            => bytes(src, count);

        /// <summary>
        /// Fills a caller-supplied buffer with source bytes
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static Span<byte> Bytes(this ISource src, Span<byte> dst)
            => bytes(src, dst);

        /// <summary>
        /// Produces an interminable stream of random bytes
        /// </summary>
        /// <param name="src">The data source</param>
        [Op]
        public static IEnumerable<byte> bytes(ISource source)
        {
            while(true)
            {
                var u64 = source.Next<ulong>();
                for(byte i=0; i<8; i++)
                    yield return core.@byte(u64, i);
            }
        }

        /// <summary>
        /// Produces a limited stream of random bytes
        /// </summary>
        /// <param name="source">The data source</param>
        /// <param name="count">The maximum number of bytes to produce</param>
        [Op]
        public static IEnumerable<byte> bytes(ISource source, int count)
        {
            var counter = 0;
            var bytes = new byte[8];
            for(var j=0; j<count; j+=8)
            {
                var src = source.Next<ulong>();
                core.deposit(src, bytes);
                for(var k=0; k<8; k++, counter++)
                {
                    if(counter == count)
                        break;

                    yield return bytes[k];
                }
            }
        }

        [Op]
        public static IEnumerable<byte> bytes(ISource source, uint count)
            => bytes(source, (int)count);

        [Op]
        public static Span<byte> bytes(ISource source, Span<byte> dst)
        {
            source.Fill(dst);
            return dst;
        }
    }
}