//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static AsciSymbols;

    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static asci64 init(N64 n, ReadOnlySpan<AsciCode> src)
            => new asci64(recover<AsciCode,byte>(src));

        [MethodImpl(Inline), Op]
        public static asci64 init(N64 n, AsciCode fill = AsciCode.Space)
            => new asci64(cpu.vbroadcast(w512, (byte)fill));

        [MethodImpl(Inline), Op]
        public static C code(in asci64 src, Hex6Kind index)
            => (C)skip(bytes(src), (byte)index);

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci64 src)
            => src.Storage.ToSpan();

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci64 encode(in char src, byte count, out asci64 dst)
        {
            dst = asci64.Null;
            ref var storage = ref @as<asci64,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
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
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci64 encode(N64 n, ReadOnlySpan<char> src)
            => encode(src, out asci64 dst);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci64 src, byte match)
            => search(@byte(edit(src)), src.Capacity, match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci64 src, char match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci64 src, AsciCode match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        [MethodImpl(Inline), Op]
        public static bool contains(in asci64 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);
        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci64 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci64 src)
            => ref @as<asci64,byte>(src);

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci64 src)
            => foundnot(index(src, z8), src.Capacity);

        [MethodImpl(Inline), Op]
        public static void store(in asci64 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci64 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> decode(in asci64 src)
        {
            var x = src.Storage;
            var x0 = vpack.vinflatelo256x16u(x.Lo);
            var x1 = vpack.vinflatehi256x16u(x.Lo);
            var x2 = vpack.vinflatelo256x16u(x.Hi);
            var x3 = vpack.vinflatehi256x16u(x.Hi);
            return slice(recover<char>(core.bytes(new V256x4(x0, x1, x2, x3))),0, src.Length);
        }

        [MethodImpl(Inline), Op]
        public static void decode(in asci64 src, ref char dst)
        {
            decode(src.Lo, ref dst);
            decode(src.Hi, ref seek(dst, 32));
        }
    }
}