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
    using static AsciChars;

    partial struct Asci
    {
        /// <summary>
        /// Presents a span of character codes as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(Span<AsciCode> src)
            => recover<AsciCode,byte>(src);

        /// <summary>
        /// Presents a span of asci symbols as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(Span<AsciSymbol> src)
            => recover<AsciSymbol,byte>(src);

        /// <summary>
        /// Selects a contiguous asci character sequence encoded as as bytespan
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> bytes(byte offset, byte count)
            => slice(CharBytes, offset, count);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci2 src)
            => core.cover(@as<byte>(src.Storage), src.Length);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci4 src)
            => core.cover(@as<byte>(src.Storage), src.Length);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci8 src)
            => core.cover(@as<byte>(src.Storage), src.Length);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci16 src)
            => src.Storage.ToSpan();

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci32 src)
            => src.Storage.ToSpan();

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci64 src)
            => src.Storage.ToSpan();
    }
}