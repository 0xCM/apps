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
    using static HexConst;

    using NBK = NumericBaseKind;
    using SQ = SymbolicQuery;

    using BSF = BinarySymFacet;
    using BDF = BinaryDigitFacets;
    using BDC = BinaryDigitCode;
    using BDS = BinaryDigitSym;
    using BDV = BinaryDigitValue;

    using ODF = OctalDigitFacets;
    using ODC = OctalDigitCode;
    using ODS = OctalDigitSym;
    using ODV = OctalDigitValue;

    using DDF = DecimalDigitFacets;
    using DSF = DecimalSymFacet;
    using DDS = DecimalDigitSym;
    using DDV = DecimalDigitValue;
    using DDC = DecimalDigitCode;

    using HDV = HexDigitValue;
    using HLS = HexLowerSym;
    using HUS = HexUpperSym;

    partial struct Digital
    {
        /// <summary>
        /// Converts a character in the inclusive range [0,9] to the corresponding number in the same range
        /// </summary>
        /// <param name="c">The digit character</param>
        [MethodImpl(Inline), Op]
        public static ulong digit(char c)
            => (ulong)c - (ulong)'0';

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 7] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static ulong digit(ulong src, byte index)
            => 0xF & (src >> index*4);

        /// <summary>
        /// Tests whether a character symbol is one of '0'..'9'
        /// </summary>
        /// <param name="src">The symbol to test</param>
        public static bit number(char c)
            => (DSF)c >= DSF.First && (DSF)c <= DSF.Last;

        [MethodImpl(Inline), Op]
        public static BDV digit(BDS s)
            => (BDV)((BSF)s - BSF.First);

        [MethodImpl(Inline), Op]
        public static DDV digit(DDS s)
            => (DDV)((DSF)s - DSF.First);

        [MethodImpl(Inline), Op]
        public static BDV digit(Base2 @base, char c)
            => (BDV)((BSF)c - BSF.First);

        [MethodImpl(Inline), Op]
        public static bool digit(Base2 @base, char c, out BDV dst)
        {
            if(Digital.test(@base, c))
            {
                dst = (BDV)((BDC)c - BDF.MinCode);
                return true;
            }
            else
            {
                dst = (BDV)0xFF;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static void digits(byte src, Span<BDV> dst)
        {
            seek(dst, 0) = (BDV)((0b00000001 & src) >> 0);
            seek(dst, 1) = (BDV)((0b00000010 & src) >> 1);
            seek(dst, 2) = (BDV)((0b00000100 & src) >> 2);
            seek(dst, 3) = (BDV)((0b00001000 & src) >> 3);
            seek(dst, 4) = (BDV)((0b00010000 & src) >> 4);
            seek(dst, 5) = (BDV)((0b00100000 & src) >> 5);
            seek(dst, 6) = (BDV)((0b01000000 & src) >> 6);
            seek(dst, 7) = (BDV)((0b10000000 & src) >> 7);
        }

        [MethodImpl(Inline), Op]
        public static void digits(ushort src, Span<BDV> dst)
        {
            digits((byte)src, dst);
            digits((byte)(src >> 8), slice(dst, 8));
        }

        [MethodImpl(Inline), Op]
        public static void digits(uint src, Span<BDV> dst)
        {
            digits((ushort)src,dst);
            digits((ushort)(src >> 16), slice(dst,16));
        }

        [MethodImpl(Inline), Op]
        public static void digits(ulong src, Span<BDV> dst)
        {
            digits((uint)src,dst);
            digits((uint)(src >> 32), slice(dst, 32));
        }

        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<bit> src, Span<BDV> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = skip(src,i);
        }


        [MethodImpl(Inline), Op]
        public static void digits(ReadOnlySpan<BDS> src, Span<BDV> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Digital.digit(skip(src,i));
        }


        [MethodImpl(Inline), Op]
        public static ODV digit(ODS s)
            => (ODV)(s - ODS.o0);

        [MethodImpl(Inline), Op]
        public static ODV digit(Base8 @base, char c)
            => (ODV)((ODS)c - ODS.o0);

        [MethodImpl(Inline), Op]
        public static bool digit(Base8 @base, char c,  out ODV dst)
        {
            if(Digital.test(@base, c))
            {
                dst = (ODV)((ODC)c - ODF.MinCode);
                return true;
            }
            else
            {
                dst = (ODV)0xFF;
                return true;
            }
        }

        /// <summary>
        /// Computes the digits corresponding to each 3-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Perm8L src, Span<ODV> dst)
            => digits((uint)src, dst);

        /// <summary>
        /// Computes the digits corresponding to each 3-bit segment of a <see cref='uint'/> value
        /// </summary>
        /// <param name="src">The perm spec</param>
        [MethodImpl(Inline), Op]
        public static uint digits(uint src, Span<ODV> dst)
        {
            //[0 1 2 | 3 4 5 | 6 7 8 | ... | 21 22 23] -> 256x32
            seek(dst,0) = (ODV)bits.segment(src, 0, 2);
            seek(dst,1) = (ODV)bits.segment(src, 3, 5);
            seek(dst,2) = (ODV)bits.segment(src, 6, 8);
            seek(dst,3) = (ODV)bits.segment(src, 9, 11);
            seek(dst,4) = (ODV)bits.segment(src, 12, 14);
            seek(dst,5) = (ODV)bits.segment(src, 15, 17);
            seek(dst,6) = (ODV)bits.segment(src, 18, 20);
            seek(dst,7) = (ODV)bits.segment(src, 21, 23);
            return 8;
        }

        [MethodImpl(Inline), Op]
        public static uint digits(byte src, Span<ODV> dst)
        {
            seek(dst,0) = (ODV)bits.segment(src, 0, 2);
            seek(dst,1) = (ODV)bits.segment(src, 3, 5);
            seek(dst,2) = (ODV)bits.segment(src, 6, 7);
            return 3;
        }

        [MethodImpl(Inline), Op]
        public static uint digits(ushort src, Span<ODV> dst)
        {
            seek(dst,0) = (ODV)bits.segment(src, 0, 2);
            seek(dst,1) = (ODV)bits.segment(src, 3, 5);
            seek(dst,2) = (ODV)bits.segment(src, 6, 8);
            seek(dst,3) = (ODV)bits.segment(src, 9, 11);
            seek(dst,4) = (ODV)bits.segment(src, 12, 14);
            seek(dst,5) = (ODV)bits.segment(src, 15, 16);
            return 3;
        }

        /// <summary>
        /// Computes the digits corresponding to each 3-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        public static Span<ODV> digits(Base8 @base, Perm8L src)
        {
            var dst = alloc<ODV>(8);
            digits(src, dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static bool digit(Base10 @base, char c, out DDV dst)
        {
            if(Digital.test(@base, c))
            {
                dst = (DDV)((DDC)c - DDF.MinCode);
                return true;
            }
            else
            {
                dst = (DDV)0xFF;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, char c)
            => (DDV)((DSF)c - DSF.First);

        [MethodImpl(Inline), Op]
        public static Span<DDV> digits(ReadOnlySpan<char> src, Span<DDV> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = digit(base10, skip(src,i));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Span<DDV> digits(Base10 @base, ulong src)
        {
            var data = src.ToString();
            var dst = sys.alloc<DDV>(data.Length);
            return digits(data, dst);
        }

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 1] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, ushort src, byte index)
            => (DDV)(F & (src >> index*4));

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 3] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, uint src, byte index)
            => (DDV)(F & (src >> index*4));

        /// <summary>
        /// Extracts an index-identified encoded digit
        /// </summary>
        /// <param name="base">The base selector</param>
        /// <param name="src">The digit source</param>
        /// <param name="index">An integer in the inclusive range [0, 7] that identifies the digit to extract</param>
        [MethodImpl(Inline), Op]
        public static DDV digit(Base10 @base, ulong src, byte index)
            => (DDV)(F & (src >> index*4));

         /// <summary>
        /// Encodes two decimal digits d := 0x[c1][c0] for characters c2, c1 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c1">The source for digit 1, the most significant digit</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong digits(Base10 @base, char c1, char c0)
            => pack(@base10, c1, c0);

        /// <summary>
        /// Encodes three decimal digits d := 0x[c2][c1][c0] for characters c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c2">The source for digit 2, the most significant digit</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong digits(Base10 @base, char c2, char c1, char c0)
            => pack(@base10, c2, c1, c0);

        /// <summary>
        /// Encodes four decimal digits d := 0x[c3][c2][c1][c0] for characters c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c3">The source for digit 3, the most significant digit</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong digits(Base10 @base, char c3, char c2, char c1, char c0)
            => pack(@base10, c3, c2, c1, c0);

        /// <summary>
        /// Encodes five decimal digits d := 0x[c4][c3][c2][c1][c0] for characters c4, c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c4">The source for digit 4, the most significant digit</param>
        /// <param name="c3">The source for digit 3</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong digits(Base10 @base, char c4, char c3, char c2, char c1, char c0)
            => pack(@base10, c4, c3, c2, c1, c0);

        /// <summary>
        /// Encodes eight decimal digits d := 0x[c7][c6][c5][c4][c3][c2][c1][c0] for characters c7, c6, c5, c4, c3, c2, c1, c0 in the inclusive range [0,9]
        /// </summary>
        /// <param name="c7">The source for digit 7, the most significant digit</param>
        /// <param name="c6">The source for digit 6</param>
        /// <param name="c5">The source for digit 5</param>
        /// <param name="c4">The source for digit 4</param>
        /// <param name="c3">The source for digit 3</param>
        /// <param name="c2">The source for digit 2</param>
        /// <param name="c1">The source for digit 1</param>
        /// <param name="c0">The source for digit 0, the least significant digit</param>
        [MethodImpl(Inline), Op]
        public static ulong digits(Base10 @base, char c7, char c6, char c5, char c4, char c3, char c2, char c1, char c0)
            => pack(@base10, c7, c6, c5, c4, c3, c2, c1, c0);

        [Op]
        public static uint digits(Base10 @base, ReadOnlySpan<char> src, uint offset, Span<DDV> dst)
        {
            var i=offset;
            var j=0u;
            var imax = src.Length - 1;
            while(i <= imax)
            {
                ref readonly var c = ref skip(src, i++);
                if(SQ.space(c) && j==0)
                    continue;

                if(SQ.digit(@base, c))
                    seek(dst, j++) = (DDV)(AsciCode.d9 - (AsciCode)c);
                else
                    break;
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, char src)
            => Hex.digit(src);

        [MethodImpl(Inline), Op]
        public static bool digit(Base16 @base, char c, out HDV dst)
            => Hex.parse(c, out dst);

        [Op]
        public static bool digit(NBK @base, char c, out byte dst)
        {
            dst = byte.MaxValue;
            switch(@base)
            {
                case NBK.Base2:
                if(Digital.digit(@base2, c, out var d2))
                {
                    dst = (byte)d2;
                    return true;
                }
                break;
                case NBK.Base8:
                if(Digital.digit(@base8, c, out var d8))
                {
                    dst = (byte)d8;
                    return true;
                }
                break;
                case NBK.Base10:
                if(Digital.digit(@base10, c, out var d10))
                {
                    dst = (byte)d10;
                    return true;
                }
                break;
                case NBK.Base16:
                if(Digital.digit(@base16, c, out var d16))
                {
                    dst = (byte)d16;
                    return true;
                }
                break;
            }
            return false;
        }

        /// <summary>
        /// Computes the digits corresponding to each 4-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        [MethodImpl(Inline), Op]
        public static uint digits(Perm16L src, Span<HDV> dst)
        {
            var scalar = (ulong)src;
            seek(dst,0) = (HDV)bits.segment(scalar, 0, 3);
            seek(dst,1) = (HDV)bits.segment(scalar, 4, 7);
            seek(dst,2) = (HDV)bits.segment(scalar, 8, 11);
            seek(dst,3) = (HDV)bits.segment(scalar, 12, 15);
            seek(dst,4) = (HDV)bits.segment(scalar, 16, 19);
            seek(dst,5) = (HDV)bits.segment(scalar, 20, 23);
            seek(dst,6) = (HDV)bits.segment(scalar, 24, 27);
            seek(dst,7) = (HDV)bits.segment(scalar, 28, 31);
            seek(dst,8) = (HDV)bits.segment(scalar, 32, 35);
            seek(dst,9) = (HDV)bits.segment(scalar, 36, 39);
            seek(dst,10) = (HDV)bits.segment(scalar, 40, 43);
            seek(dst,11) = (HDV)bits.segment(scalar, 44, 47);
            seek(dst,12) = (HDV)bits.segment(scalar, 48, 53);
            seek(dst,13) = (HDV)bits.segment(scalar, 52, 55);
            seek(dst,14) = (HDV)bits.segment(scalar, 56, 59);
            seek(dst,15) = (HDV)bits.segment(scalar, 60, 63);
            return 16;
        }

        /// <summary>
        /// Computes the digits corresponding to each 4-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        public static Span<HDV> digits(Base16 @base, Perm16L src)
        {
            var dst = alloc<HDV>(16);
            digits(src, dst);
            return dst;
        }

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, LowerCased @case, char src)
            => Hex.digit(@case, src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(Base16 @base, UpperCased @case, char src)
            => Hex.digit(@case, src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by a lowercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(HLS src)
            => Hex.digit(src);

        /// <summary>
        /// Computes the numeric value in in the range [0,..F] identified by an uppercase hex symbol
        /// </summary>
        /// <param name="src">The source symbol</param>
        [MethodImpl(Inline), Op]
        public static HDV digit(HUS src)
            => Hex.digit(src);

        /// <summary>
        /// Extracts two encoded digits
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="d1">The most significant digit</param>
        /// <param name="d0">The least significant digit</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, out byte d1, out byte d0)
        {
            d1 = (byte)digit(src,1);
            d0 = (byte)digit(src,0);
        }

        [MethodImpl(Inline), Op]
        public static void digits(ulong src, out byte d2, out byte d1, out byte d0)
        {
            d2 = (byte)digit(src,2);
            d1 = (byte)digit(src,1);
            d0 = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first digit from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N1 n, ref byte dst)
            => add(dst, 0) = (byte)digit(src,0);

        /// <summary>
        /// Extracts the first two digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N2 n, ref byte dst)
        {
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first three digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N3 n, ref byte dst)
        {
            add(dst, 2) = (byte)digit(src,2);
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first four digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N4 n, ref byte dst)
        {
            add(dst, 3) = (byte)digit(src,3);
            add(dst, 2) = (byte)digit(src,2);
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first five digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N5 n, ref byte dst)
        {
            add(dst, 4) = (byte)digit(src,4);
            add(dst, 3) = (byte)digit(src,3);
            add(dst, 2) = (byte)digit(src,2);
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first six digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N6 n, ref byte dst)
        {
            add(dst, 5) = (byte)digit(src,5);
            add(dst, 4) = (byte)digit(src,4);
            add(dst, 3) = (byte)digit(src,3);
            add(dst, 2) = (byte)digit(src,2);
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Extracts the first seven digits from the source
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="n">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void digits(ulong src, N7 n, ref byte dst)
        {
            add(dst, 6) = (byte)digit(src,6);
            add(dst, 5) = (byte)digit(src,5);
            add(dst, 4) = (byte)digit(src,4);
            add(dst, 3) = (byte)digit(src,3);
            add(dst, 2) = (byte)digit(src,2);
            add(dst, 1) = (byte)digit(src,1);
            add(dst, 0) = (byte)digit(src,0);
        }

        /// <summary>
        /// Computes the digits corresponding to each 2-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        [MethodImpl(Inline), Op]
        public static void digits(Perm4L src, Span<byte> dst)
        {
            var scalar = (byte)src;
            seek(dst,0) = bits.segment(scalar, 0, 1);
            seek(dst,1) = bits.segment(scalar, 2, 3);
            seek(dst,2) = bits.segment(scalar, 4, 5);
            seek(dst,3) = bits.segment(scalar, 6, 7);
        }

        /// <summary>
        /// Computes the digits corresponding to each 2-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        [MethodImpl(Inline), Op]
        public static ref readonly NatSpan<N4,byte> digits(Perm4L src, in NatSpan<N4,byte> dst)
        {
            var scalar = (byte)src;
            dst[0] = bits.segment(scalar, 0, 1);
            dst[1] = bits.segment(scalar, 2, 3);
            dst[2] = bits.segment(scalar, 4, 5);
            dst[3] = bits.segment(scalar, 6, 7);
            return ref dst;
        }

        /// <summary>
        /// Computes the digits corresponding to each 2-bit segment of the permutation spec
        /// </summary>
        /// <param name="src">The perm spec</param>
        public static NatSpan<N4,byte> digits(Perm4L src)
            => digits(src, NatSpans.alloc<N4,byte>());
    }
}