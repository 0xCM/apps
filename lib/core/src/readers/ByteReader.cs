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

    [ApiHost]
    public readonly struct ByteReader
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Reads the bytes that define a numeric value
        /// </summary>
        /// <param name="src">The value to read</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> read8(in long src)
            => new Span<byte>(gptr(in src), 8);

        /// <summary>
        /// Reads the bytes that define a numeric value
        /// </summary>
        /// <param name="src">The value to read</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> read8(in ulong src)
            => new Span<byte>(gptr(src), 8);

        /// <summary>
        /// Reads the bytes that define a numeric value
        /// </summary>
        /// <param name="src">The value to read</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> read8(in double src)
            => new Span<byte>(gptr(src), 8);

        /// <summary>
        /// Reads 2 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref readonly ushort read2(in byte src)
            => ref @as<ushort>(src);

        /// <summary>
        /// Reads 3 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ulong read3(in byte src)
        {
            var dst = 0ul;
            var i = 0u;
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            return dst;
        }

        /// <summary>
        /// Reads 4 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref readonly uint read4(in byte src)
            => ref @as<uint>(src);

        /// <summary>
        /// Reads 5 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ulong read5(in byte src)
        {
            var dst = 0ul;
            var i = 0u;
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static byte read1(in byte src, Span<byte> dst)
        {
            first(dst) = src;
            return 1;
        }

        [MethodImpl(Inline), Op]
        public static byte read2(in byte src, Span<byte> dst)
        {
            first(recover<ushort>(dst)) = u16(src);
            return 2;
        }

        /// <summary>
        /// Reads 5 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static byte read3(in byte src, Span<byte> dst)
        {
            read2(src,dst);
            seek(dst,3) = skip(src,3);
            return 3;
        }

        [MethodImpl(Inline), Op]
        public static byte read4(in byte src, Span<byte> dst)
        {
            first(recover<uint>(dst)) = u32(src);
            return 4;
        }

        /// <summary>
        /// Reads 5 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static byte read5(in byte src, Span<byte> dst)
        {
            read4(src,dst);
            seek(dst,4) = skip(src,4);
            return 5;
        }

        /// <summary>
        /// Reads 6 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static byte read6(in byte src, Span<byte> dst)
        {
            read4(src,dst);
            read2(skip(src,4), slice(dst,4));
            return 6;
        }

        /// <summary>
        /// Reads 6 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static byte read7(in byte src, Span<byte> dst)
        {
            read4(src,dst);
            read3(skip(src,4), slice(dst,4));
            return 7;
        }

        /// <summary>
        /// Reads 6 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static byte read8(in byte src, Span<byte> dst)
        {
            first(recover<ulong>(dst)) = u64(src);
            return 8;
        }

        /// <summary>
        /// Reads 6 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ulong read6(in byte src)
        {
            var dst = 0ul;
            var i = 0u;
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            return dst;
        }

        /// <summary>
        /// Reads 7 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ulong read7(in byte src)
        {
            var dst = 0ul;
            var i = 0u;
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            return dst;
        }

        /// <summary>
        /// Reads 8 bytes from a data source reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ulong read8(in byte src)
        {
            var dst = 0ul;
            var i = 0u;
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            seek8(dst, i++) = skip(src,i);
            return dst;
        }
    }
}