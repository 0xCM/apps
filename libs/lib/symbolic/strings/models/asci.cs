//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static AsciSymbols;
    using static AsciChars;

    using C = AsciCode;

    [ApiHost]
    public readonly partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static AsciSeq seq(uint size)
            => new AsciSeq(alloc<byte>(size));

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(byte[] src)
            => new AsciSeq(src);

        public static uint render(AsciSeq src, uint length, Span<char> dst)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return size;
        }

        [MethodImpl(Inline), Op]
        public static void decode(N48 n, ReadOnlySpan<byte> src, Span<char> dst)
        {
            ref var target = ref @as<ushort>(first(dst));
            var v = cpu.vload(w256, src);
            var offset = z8;
            cpu.vstore(vpack.vinflatelo256x16u(v), ref target);
            offset+=16;
            cpu.vstore(vpack.vinflatehi256x16u(v), ref seek(target,offset));
            offset+=16;
            decode(n16, core.slice(src,offset), core.slice(dst,offset));
        }

        [MethodImpl(Inline), Op]
        public static ByteSize unpack(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0u;
            for(var i=0u; i<count; i++, j+=2)
                seek(dst,j) = (byte)skip(src,i);
            return count;
        }

        /// <summary>
        /// Tests whether a byte represents corresponds to an valid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool valid(byte src)
            => src <= AsciCodeFacets.MaxCodeValue;

        /// <summary>
        /// Tests whether a byte represents corresponds to an invalid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool invalid(byte src)
            => !valid(src);

        /// <summary>
        /// if given a lowercase character [a..z], produces the corresponding uppercase character [A..z]
        /// Otherwise, returns the input unharmed
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static char uppercase(char src)
             => letter(LowerCase, src) ? uppercase((AsciLetterLoCode)src) : src;

        [MethodImpl(Inline), Op]
        public static char uppercase(AsciLetterLoCode src)
            => skip(UppercaseLetters,(uint)src - (uint)AsciLetterLoCode.First);

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciCode src)
            => src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterLoSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterUpSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static ref readonly AsciSymbol symbol(in byte src)
            => ref core.view<byte,AsciSymbol>(src);

        [MethodImpl(Inline), Op]
        public static void store(ReadOnlySpan<byte> src, char fill, Span<char> dst)
        {
            var count = core.length(src,dst);
            for(var i=0u; i<count; i++)
            {
                ref readonly var next = ref skip(src,i);
                seek(dst,i) = next == 0 ? fill : @char(skip(src,i));
            }
        }

        [MethodImpl(Inline)]
        public static bool bitstring<S>(S src)
            where S : unmanaged, IAsciSeq<S>
        {
            var result = true;
            var counter = 0;
            var data = src.View;
            var n = data.Length;
            for(var i=0; i<n; i++)
            {
                var b = (AsciCode)skip(data,i);
                result = (b == AsciCode.Space || b == AsciCode.d0 || b == AsciCode.d1);
                if(!result)
                    break;
            }

            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool contains(AsciSeq src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains<T>(AsciSeq<T> src, char match)
            where T : unmanaged, IAsciSeq<T>
                => AsciG.contains(src, (AsciCharSym)match);

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
        /// Tests whether a character is an uppercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(UpperCased @case, char c)
            => (C)c >= AsciCodeFacets.MinUpperLetter && (C)c <= AsciCodeFacets.MaxUpperLetter;

        /// <summary>
        /// Tests whether a character is a lowercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(LowerCased @case, char c)
            => (C)c >= AsciCodeFacets.MinLowerLetter && (C)c <= AsciCodeFacets.MaxLowerLetter;

        /// <summary>
        /// Tests whether a character is an asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(char c)
            => letter(UpperCase, c) || letter(LowerCase, c);

        /// <summary>
        /// Presents the input  as a byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in AsciCode src)
            => ref @as<AsciCode,byte>(src);

        [MethodImpl(Inline), Op]
        public static char @char(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char @char(AsciSymbol src)
            => (char)src;

        /// <summary>
        /// Returns the asci characters corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(sbyte offset, sbyte count)
            => slice(recover<char>(AsciChars.CharBytes), offset, count);

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<C> src, Span<char> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return count;
        }


        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<char> src, Span<C> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (C)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<char> x, ReadOnlySpan<AsciCode> y)
        {
            var count = x.Length;
            if(count != y.Length)
                return false;

            for(var i=0u; i<count; i++)
                if((byte)skip(x,i) != (byte)skip(y,i))
                    return false;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(ReadOnlySpan<AsciCode> x, ReadOnlySpan<char> y)
            => eq(y,x);

        [MethodImpl(Inline), Op]
        public static string format(AsciSymbol src)
            => src.Text;

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            var dst = span<char>(src.Length);
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciCode> src)
        {
            var dst = span<char>(src.Length);
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<AsciSymbol> src)
        {
            var dst = span<char>(src.Length);
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

        [MethodImpl(Inline), Op]
        public static ushort pack(char c0, char c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(char c0, char c1, char c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(char c0, char c1, char c2, char c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5, char c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;


        [MethodImpl(Inline), Op]
        public static ushort pack(C c0, C c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2, C c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5, C c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5, C c6, C c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;


        [MethodImpl(Inline), Op]
        public static ushort pack(byte c0, byte c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(byte c0, byte c1, byte c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(byte c0, byte c1, byte c2, byte c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5, byte c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;

        public static AsciNull Null
            => default;

        [Op]
        public static AsciSeq subseq<T>(T src, int i0, int i1)
            where T : unmanaged, IAsciSeq
                => new AsciSeq(core.segment(src.View, i0, i1).ToArray());

        [MethodImpl(Inline), Op]
        public static Vector128<ushort> decode(ulong src)
            => cpu.vlo(vpack.vinflate256x16u(cpu.v8u(cpu.vscalar(src))));

        [MethodImpl(Inline), Op]
        public static Vector256<ushort> decode(Vector128<byte> src)
            => vpack.vinflate256x16u(src);

        [MethodImpl(Inline), Op]
        public static Vector512<ushort> decode(Vector256<byte> src)
            => cpu.vparts(w512, vpack.vinflatelo256x16u(src), vpack.vinflatehi256x16u(src));

        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> vbroadcast(W128 w, char src)
            => cpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> vbroadcast(W256 w, char src)
            => cpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> vbroadcast(W128 w, C src)
            => cpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> vbroadcast(W256 w, C src)
            => cpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 8 components of a 128x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<ushort> vbroadcast(W128 w, AsciCharSym src)
            => cpu.vbroadcast(w,(ushort)src);

        /// <summary>
        /// Populates the 16 components of a 256x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<ushort> vbroadcast(W256 w, AsciCharSym src)
            => cpu.vbroadcast(w,(ushort)src);

    }
}