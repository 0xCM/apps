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

    partial struct Asci
    {
        /// <summary>
        /// Encodes a 2-character asci sequence
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        [MethodImpl(Inline), Op]
        public static asci2 encode(char a, char b)
            => new asci2(AsciSymbols.pack((AsciCode)a, (AsciCode)b));

        /// <summary>
        /// Encodes a 3-character asci sequence
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        /// <param name="c">The third asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(char a, char b, char c)
            => new asci4(AsciSymbols.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(char a, char b, char c, char d)
            => new asci4(AsciSymbols.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, (AsciCode)d, out var _ ));

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci2 encode(in char src, Hex1Seq count, out asci2 dst)
        {
            dst = asci2.Null;
            ref var codes = ref Unsafe.As<asci2,AsciCode>(ref dst);
            AsciSymbols.codes(src, (byte)count, ref codes);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci4 encode(in char src, Hex2Seq count, out asci4 dst)
        {
            dst = asci4.Null;
            ref var storage = ref Unsafe.As<asci4,AsciCode>(ref dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci8 encode(in char src, Hex3Seq count, out asci8 dst)
        {
            dst = asci8.Null;
            ref var storage = ref @as<asci8,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci16 encode(in char src, Hex4Seq count, out asci16 dst)
        {
            dst = asci16.Null;
            ref var storage = ref @as<asci16,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci32 encode(in char src, Hex5Seq count, out asci32 dst)
        {
            dst = asci32.Null;
            ref var storage = ref @as<asci32,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci64 encode(in char src, Hex6Seq count, out asci64 dst)
        {
            dst = asci64.Null;
            ref var storage = ref @as<asci64,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates a 2-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci2 encode(ReadOnlySpan<char> src, out asci2 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci2,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci4 encode(ReadOnlySpan<char> src, out asci4 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci4,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates an 8-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci8 encode(ReadOnlySpan<char> src, out asci8 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci8,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates a 16-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci16 encode(ReadOnlySpan<char> src, out asci16 dst)
        {
            dst = asci16.Spaced;
            AsciSymbols.codes(src, span<asci16,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci32 encode(ReadOnlySpan<char> src, out asci32 dst)
        {
            dst = asci32.Spaced;
            AsciSymbols.codes(src, span<asci32,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates a 64-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci64 encode(ReadOnlySpan<char> src, out asci64 dst)
        {
            dst = asci64.Spaced;
            AsciSymbols.codes(src, span<asci64,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Populates a 2-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci2 encode(N2 n, ReadOnlySpan<char> src)
            => encode(src, out asci2 dst);

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, ReadOnlySpan<char> src)
            => encode(src, out asci4 dst);

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref ByteBlock4 encode(ReadOnlySpan<char> src, ref ByteBlock4 dst)
        {
            AsciSymbols.encode(src, dst.Bytes);
            return ref dst;
        }

        /// <summary>
        /// Populates an 8-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci8 encode(N8 n, ReadOnlySpan<char> src)
            => encode(src, out asci8 dst);

        /// <summary>
        /// Populates a 16-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci16 encode(N16 n, ReadOnlySpan<char> src)
            => encode(src, out asci16 dst);

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci32 encode(N32 n, ReadOnlySpan<char> src)
            => encode(src, out asci32 dst);

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci64 encode(N64 n, ReadOnlySpan<char> src)
            => encode(src, out asci64 dst);
    }
}