//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;
    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Bytes
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b)
            => (ulong)a | (ulong)b << 8;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c, byte d)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16 | (ulong)d << 24;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c, byte d, byte e)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16 | (ulong)d << 24
             | (ulong)e << 32;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c, byte d, byte e, byte f)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16 | (ulong)d << 24
             | (ulong)e << 32 | (ulong)f << 40;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c, byte d, byte e, byte f, byte g)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16 | (ulong)d << 24
             | (ulong)e << 32 | (ulong)f << 40 | (ulong)g << 48;

        [MethodImpl(Inline), Op]
        public static ulong join(W64 w, byte a, byte b, byte c, byte d, byte e, byte f, byte g, byte h)
            => (ulong)a | (ulong)b << 8 | (ulong)c << 16 | (ulong)d << 24
             | (ulong)e << 32 | (ulong)f << 40 | (ulong)g << 48 | (ulong)h << 56;

        /// <summary>
        /// Extracts an index-identified source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The byte relative index</param>
        [MethodImpl(Inline), Op]
        public static byte extract(ushort src, byte index)
            => (byte)(src >> (index*8));

        /// <summary>
        /// Extracts an index-identified source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The byte relative index</param>
        [MethodImpl(Inline), Op]
        public static byte extract(uint src, byte index)
            => (byte)(src >> (index*8));

        /// <summary>
        /// Extracts an index-identified source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The byte relative index</param>
        [MethodImpl(Inline), Op]
        public static byte extract(ulong src, byte index)
            => (byte)(src >> (index*8));

        /// <summary>
        /// Overwrites an index-identified byte in the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The byte relative index</param>
        /// <param name="src">The target</param>
        [MethodImpl(Inline), Op]
        public static ref uint inject(in byte src, byte index, ref uint dst)
        {
            dst &= (0xFFu << (index*3));
            dst &= (~(uint)src);
            return ref dst;
        }

        /// <summary>
        /// Overwrites an index-identified byte in the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The byte relative index</param>
        /// <param name="src">The target</param>
        [MethodImpl(Inline), Op]
        public static ref ulong inject(in byte src, byte index, ref ulong dst)
        {
            dst &= (0xFFul << (index*3));
            dst &= (~(ulong)src);
            return ref dst;
        }

        /// <summary>
        /// Returns a readonly reference to an index-identified source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The 0-based, byte-relative index</param>
        /// <typeparam name="T">The data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte view<T>(in T src, byte index)
            where T : unmanaged
        {
            ref readonly var data = ref @as<T,byte>(src);
            return ref skip(data,index);
        }

        /// <summary>
        /// Returns a mutable reference to an index-identified source byte
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="index">The 0-based, byte-relative index</param>
        /// <typeparam name="T">The data type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte edit<T>(ref T src, byte index)
            where T : unmanaged
        {
            ref var data = ref @as<T,byte>(src);
            return ref seek(data,index);
        }

        /// <summary>
        /// Converts an input sequence to a 16-bit unsigned integer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<byte> src, W16 w)
        {
            var n = max(src.Length, 2);
            var dst = z16;
            var b = bytes(dst);
            for(var k=0; k<n; k++)
                seek(b,k) = skip(src,k);
            return dst;
        }

        /// <summary>
        /// Converts an input sequence to a 32-bit unsigned integer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static uint convert(ReadOnlySpan<byte> src, W32 w)
        {
            var n = max(src.Length, 4);
            var dst = 0u;
            var b = bytes(dst);
            for(var k=0; k<n; k++)
                seek(b,k) = skip(src,k);
            return dst;
        }

        /// <summary>
        /// Converts an input sequence to a 64-bit unsigned integer
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="w">The target width</param>
        [MethodImpl(Inline), Op]
        public static ulong convert(ReadOnlySpan<byte> src, W64 w)
        {
            var n = max(src.Length, 8);
            var dst = 0ul;
            var b = bytes(dst);
            for(var k=0; k<n; k++)
                seek(b,k) = skip(src,k);
            return dst;
        }

        /// <summary>
        /// Determines whether cell[i] == a0 && cell[i+i] == a1
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="i">The start index</param>
        /// <param name="a0">The first value to match</param>
        /// <param name="a1">The second value to match</param>
        [MethodImpl(Inline), Op]
        public static bool match(ReadOnlySpan<byte> src, uint i, byte a0, byte a1)
            => skip(src,i) == a0 && skip(src, i + 1) == a1;

        /// <summary>
        /// Joins three operands via the bitwise or operator
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Or]
        public static byte or(byte a, byte b, byte c)
            => (byte)(a | b | c);

        /// <summary>
        /// Joins four operands via the bitwise or operator
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Or]
        public static byte or(byte a, byte b, byte c, byte d)
            => (byte)(a | b | c | d);

        /// <summary>
        /// Joins five operands via the bitwise or operator
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        /// <param name="d">The fourth operand</param>
        [MethodImpl(Inline), Or]
        public static byte or(byte a, byte b, byte c, byte d, byte e)
            => (byte)(a | b | c | d | e);

        [MethodImpl(Inline), Or]
        public static void or(in byte a, in byte b, ref byte dst)
            => store8(or(read8(a), read8(b)), ref dst);

        [MethodImpl(Inline), Xor]
        public static byte xor(byte a, byte b)
            => (byte)(a ^ b);

        [MethodImpl(Inline), Xor]
        public static void xor(in byte a, in byte b, ref byte c)
            => store8(xor(read8(a), read8(b)), ref c);

        [MethodImpl(Inline), Not]
        public static byte not(byte src)
            => (byte)(~ src);

        [MethodImpl(Inline), Not]
        public static void not(in byte A, ref byte Z)
            => store8(not(read8(A)), ref Z);

        [MethodImpl(Inline), And]
        public static void and(in byte A, in byte B, ref byte Z)
            => store8(and(read8(A), read8(B)), ref Z);

        /// <summary>
        /// Computes the bitwise nand c := ~(a & b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal operand type</typeparam>
        [MethodImpl(Inline), Nand]
        public static byte nand(byte a, byte b)
            => not(and(a,b));

        [MethodImpl(Inline), Nand]
        public static void nand(in byte A, in byte B, ref byte Z)
            => store8(nand(read8(A), read8(B)), ref Z);

        /// <summary>
        /// Computes the bitwise nor c := ~(a | b) for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Nor]
        public static byte nor(byte a, byte b)
            => not(or(a,b));

        /// <summary>
        /// Computes the bitwise nor c := ~(a | b) for operands a and b
        /// and deposits the result to a reference-identified location
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="dst">The target reference</param>
        [MethodImpl(Inline), Nor]
        public static void nor(in byte a, in byte b, ref byte dst)
            => store8(nor(read8(a), read8(b)), ref dst);

        [MethodImpl(Inline), Xnor]
        public static byte xnor(byte a, byte b)
            => not(xor(a,b));

        [MethodImpl(Inline), Xnor]
        public static void xnor(in byte A, in byte B, ref byte Z)
            => store8(xnor(read8(A), read8(B)), ref Z);

        /// <summary>
        /// Computes the material nonimplication z := ~a & b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), NonImpl]
        public static byte nonimpl(byte a, byte b)
            => (byte)AndNot((uint)a,(uint)b);

        [MethodImpl(Inline), NonImpl]
        public static void nonimpl(in byte A, in byte B, ref byte Z)
            => store8(nonimpl(read8(A), read8(B)), ref Z);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), Impl]
        public static byte impl(byte a, byte b)
            => (byte)(a | ~b);

        /// <summary>
        /// Computes the material implication c := a | ~b for operands a and b
        /// and deposits the result to a reference-identified location
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="dst">The target reference</param>
        [MethodImpl(Inline), Impl]
        public static void impl(in byte a, in byte b, ref byte dst)
            => store8(impl(read8(a), read8(b)), ref dst);

        /// <summary>
        /// Computes the converse implication c := ~a | b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CImpl]
        public static byte cimpl(byte a, byte b)
            => (byte)(~a | b);

        /// <summary>
        /// Computes the converse implication c := ~a | b for operands a and b
        /// and deposits the result to a reference-identified location
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <param name="dst">The target reference</param>
        [MethodImpl(Inline), CImpl]
        public static void cimpl(in byte A, in byte B, ref byte Z)
            => store8(cimpl(read8(A), read8(B)), ref Z);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b for operands a and b
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static byte cnonimpl(byte a, byte b)
            => (byte)AndNot((uint)b,(uint)a);

        [MethodImpl(Inline), CNonImpl]
        public static void cnonimpl(in byte a, in byte b, ref byte dst)
            => dst = cnonimpl(a, b);

        [MethodImpl(Inline), XorNot]
        public static void xornot(in byte A, in byte B, ref byte dst)
            => dst = xor(A, not(B));

        /// <summary>
        /// Computes the bitwise select among the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <param name="c">The third operand</param>
        [MethodImpl(Inline), Select]
        public static byte select(byte a, byte b, byte c)
            => or(and(a,b), nonimpl(a,c));

        [MethodImpl(Inline), Select]
        public static void select(in byte a, in byte b, in byte c, ref byte dst)
            => dst = select(a,b,c);

        [MethodImpl(Inline), Op]
        public static uint join(byte a, byte b, byte c, byte d)
        {
            var au = (uint)a;
            var bu = (uint)b << 8;
            var cu = (uint)c << 16;
            var du = (uint)d << 24;
            return au | bu | cu | du;
        }

        [MethodImpl(Inline), Op]
        public static byte inc(byte x)
            => (byte)(++x);

        [MethodImpl(Inline), Op]
        public static byte dec(byte x)
            => (byte)(--x);

        [MethodImpl(Inline), Op]
        public static byte sll(byte x, byte count)
            => (byte)(x << count);

        [MethodImpl(Inline), Op]
        public static byte srl(byte x, byte count)
            => (byte)(x >> count);

        [MethodImpl(Inline), Op]
        public static byte add(byte a, byte b)
            => (byte)(a + b);

        [MethodImpl(Inline), Op]
        public static byte sub(byte a, byte b)
            => (byte)(a - b);

        [MethodImpl(Inline), Op]
        public static byte mod(byte a, byte b)
            => (byte)(a % b);

        [MethodImpl(Inline), Op]
        public static byte mul(byte a, byte b)
            => (byte)(a * b);

        [MethodImpl(Inline), Op]
        public static byte and(byte a, byte b)
            => (byte)(a & b);

        [MethodImpl(Inline), Op]
        public static byte or(byte a, byte b)
            => (byte)(a | b);

        [MethodImpl(Inline), Op]
        public static bool gt(byte a, byte b)
            => a > b;

        [MethodImpl(Inline), Op]
        public static bool gteq(byte a, byte b)
            => a >= b;

        [MethodImpl(Inline), Op]
        public static bool lt(byte a, byte b)
            => a < b;

        [MethodImpl(Inline), Op]
        public static bool lteq(byte a, byte b)
            => a <= b;

        [MethodImpl(Inline), Op]
        public static bool eq(byte a, byte b)
            => a == b;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N2 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,2));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N4 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,4));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N8 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,8));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N16 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,16));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N32 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,32));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N64 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,64));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N128 n)
            where T : unmanaged
                => recover<byte,T>(slice(B256x8u,0,128));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> cells<T>(N256 n)
            where T : unmanaged
                => recover<byte,T>(B256x8u);

        [MethodImpl(Inline)]
        static unsafe byte read8(in byte src)
            => *(byte*)gptr(in src);

        [MethodImpl(Inline)]
        static unsafe ref byte store8(byte src, ref byte dst)
        {
            *(gptr(dst)) = src;
            return ref dst;
        }

        internal static ReadOnlySpan<byte> B256x8u => new byte[Pow2.T08]{
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f,
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f,
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f,
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f,
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f,
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f,
            0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f,
            0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f,
            0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf,
            0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf,
            0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf,
            0xd0, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf,
            0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef,
            0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xff, 0xfc, 0xfd, 0xfe, 0xff,
        };
    }
}