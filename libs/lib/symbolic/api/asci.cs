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
        static uint available(ReadOnlySpan<byte> src)
        {
            var present = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(skip(src,i) != 0)
                    present++;
                else
                    break;
            }
            return present;
        }


        [MethodImpl(Inline), Op]
        public static int length(ReadOnlySpan<byte> src)
            => foundnot(search(src, z8), src.Length);

        [MethodImpl(Inline), Op]
        public static int search(in byte src, int count, byte match)
        {
            for(var i=0u; i<count; i++)
                if(skip(src,i) == match)
                    return (int)i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int search(ReadOnlySpan<byte> src, byte match)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                if(skip(src, i) == match)
                    return (int)i;
            return NotFound;
        }

        /// <summary>
        /// Transforms an uppercase character [A..Z] to the corresponding lowercase character [a..z];
        /// if the source character is not in the letter domain, the input is returned unharmed
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static char lowercase(char src)
             => letter(UpperCase, src)  ? lowercase((AsciLetterUpCode)src)  : src;

        [MethodImpl(Inline), Op]
        public static char lowercase(AsciLetterUpCode src)
            => skip(AsciSymbols.LowercaseLetters, (uint)src - (uint)AsciCodeFacets.MinUpperLetter);

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(uint size)
            => new AsciSeq(alloc<byte>(size));

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(byte[] src)
            => new AsciSeq(src);

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src)
        {
            var buffer = alloc<byte>(src.Length);
            var seq = new AsciSeq(buffer);
            return encode(src, seq);
        }

        [MethodImpl(Inline), Op]
        public static AsciSeq seq(string src, byte[] dst)
        {
            encode(src,dst);
            return seq(dst);
        }

        [MethodImpl(Inline)]
        public static AsciSeq<A> seq<A>(A content)
            where A : unmanaged, IAsciSeq<A>
                => new AsciSeq<A>(content);

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
        public static string format(AsciSymbol src)
            => src.Text;

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
    }
}