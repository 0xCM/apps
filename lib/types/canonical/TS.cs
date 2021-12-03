//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    using static Root;
    using static core;

    using ScalarTypes;

    public readonly partial struct TS
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> seq<T>(T[] src)
            => new Seq<T>(src);

        [Op, Closures(Closure)]
        public static Seq<N,T> seq<N,T>()
            where N : unmanaged, ITypeNat
                => new Seq<N,T>(alloc<T>(nat32u<N>()));

        [MethodImpl(Inline), Op]
        public static u1<bit> u1(bit src)
            => new u1<bit>(src);

        [MethodImpl(Inline), Op]
        public static u1<byte> u1(byte src)
            => new u1<byte>(src);

        [MethodImpl(Inline), Op]
        public static u2<byte> u2(byte src)
            => new u2<byte>(src);

        [MethodImpl(Inline), Op]
        public static u3<byte> u3(byte src)
            => new u3<byte>(src);

        [MethodImpl(Inline), Op]
        public static u4<byte> u4(byte src)
            => new u4<byte>(src);

        [MethodImpl(Inline), Op]
        public static u5<byte> u5(byte src)
            => new u5<byte>(src);

        [MethodImpl(Inline), Op]
        public static u6<byte> u6(byte src)
            => new u6<byte>(src);

        [MethodImpl(Inline), Op]
        public static u8 u8(byte src)
            => new u8(src);

        [MethodImpl(Inline), Op]
        public static u16<ushort> u16(ushort src)
            => new u16<ushort>(src);

        [MethodImpl(Inline), Op]
        public static u32<uint> u32(uint src)
            => new u32<uint>(src);

        [MethodImpl(Inline), Op]
        public static u64<ulong> u64(ulong src)
            => new u64<ulong>(src);

        [MethodImpl(Inline), Op]
        public static uN<T> uN<T>(uint n, T value = default)
            where T : unmanaged
                => new uN<T>(n,value);

        /// <summary>
        /// Creates the empty vector
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v0<T> v<T>(N0 n)
            where T : unmanaged
                => default;
        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v1<T> v<T>(N1 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v1<T> v<T>(N1 n, T a0)
            where T : unmanaged
                => a0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v1<T> src)
            where T : unmanaged
                => ref @as<v1<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v1<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v2<T> v<T>(N2 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v2<T> v<T>(N2 n, T a0, T a1 = default)
            where T : unmanaged
        {
            var v = new v2<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v2<T> src)
            where T : unmanaged
                => ref @as<v2<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v2<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v2<T> src)
            where T : unmanaged
                => string.Format(RP.V2, src[0], src[1]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(N3 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(N3 n, T a0, T a1 = default, T a2 = default)
            where T : unmanaged
        {
            var v = new v3<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v3<T> v<T>(T a0, T a1, T a2)
            where T : unmanaged
        {
            var v = new v3<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v3<T> src)
            where T : unmanaged
                => ref @as<v3<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v3<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v3<T> src)
            where T : unmanaged
                => string.Format(RP.V3,
                    src[0], src[1], src[2]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n, T a0, T a1 = default, T a2 = default, T a3 = default)
            where T : unmanaged
        {
            var v = new v4<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v4<T> v<T>(N4 n, v2<T> a0, v2<T> a1)
            where T : unmanaged
        {
            var v = new v4<T>();
            lo(ref v) = a0;
            hi(ref v) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v4<T> src)
            where T : unmanaged
                => ref @as<v4<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v2<T> lo<T>(ref v4<T> src)
            where T : unmanaged
                => ref @as<v4<T>,v2<T>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v2<T> hi<T>(ref v4<T> src)
            where T : unmanaged
                => ref seek(@as<v4<T>,v2<T>>(src),1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v4<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v4<T> src)
            where T : unmanaged
                => string.Format(RP.V4, src[0], src[1], src[2], src[3]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v5<T> v<T>(N5 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v5<T> v<T>(N5 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default)
            where T : unmanaged
        {
            var v = new v5<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v5<T> src)
            where T : unmanaged
                => ref @as<v5<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v5<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v5<T> src)
            where T : unmanaged
                => string.Format(RP.V5,
                    src[0], src[1], src[2], src[3], src[4]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v6<T> v<T>(N6 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v6<T> v<T>(N6 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default)
            where T : unmanaged
        {
            var v = new v6<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v6<T> src)
            where T : unmanaged
                => ref @as<v6<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v6<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v6<T> src)
            where T : unmanaged
                => string.Format(RP.V6,
                    src[0], src[1], src[2], src[3], src[4], src[5]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v7<T> v<T>(N7 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v7<T> v<T>(N7 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default)
            where T : unmanaged
        {
            var v = new v7<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v7<T> src)
            where T : unmanaged
                => ref @as<v7<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v7<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v7<T> src)
            where T : unmanaged
                => string.Format(RP.V7,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[7]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v8<T> v<T>(N8 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v8<T> v<T>(N8 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default, T a7 = default)
            where T : unmanaged
        {
            var v = new v8<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            seek(dst,7) = a7;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v8<T> src)
            where T : unmanaged
                => ref @as<v8<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v4<T> lo<T>(ref v8<T> src)
            where T : unmanaged
                => ref @as<v8<T>,v4<T>>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref v4<T> hi<T>(ref v8<T> src)
            where T : unmanaged
                => ref seek(@as<v8<T>,v4<T>>(src),1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v8<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v8<T> src)
            where T : unmanaged
                => string.Format(RP.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v9<T> v<T>(N9 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v9<T> v<T>(N9 n, T a0, T a1 = default, T a2 = default, T a3 = default, T a4 = default, T a5 = default, T a6 = default, T a7 = default, T a8 = default)
            where T : unmanaged
        {
            var v = new v9<T>();
            ref var dst = ref cell(ref v);
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            seek(dst,2) = a2;
            seek(dst,3) = a3;
            seek(dst,4) = a4;
            seek(dst,5) = a5;
            seek(dst,6) = a6;
            seek(dst,7) = a7;
            seek(dst,8) = a8;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v9<T> src)
            where T : unmanaged
                => ref @as<v9<T>,T>(src);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v9<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v9<T> src)
            where T : unmanaged
                => string.Format(RP.V9,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7], src[8]);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v10<T> v<T>(N10 n)
            where T : unmanaged
                => default;

        public static string format<T>(in v10<T> src)
            where T : unmanaged
                => string.Format(RP.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v10<T> src)
            where T : unmanaged
                => ref @as<v10<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v10<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v11<T> v<T>(N11 n)
            where T : unmanaged
                => default;

        public static string format<T>(in v11<T> src)
            where T : unmanaged
                => string.Format(RP.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9], src[10]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v11<T> src)
            where T : unmanaged
                => ref @as<v11<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v11<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v12<T> v<T>(N12 n)
            where T : unmanaged
                => default;
        public static string format<T>(in v12<T> src)
            where T : unmanaged
                => string.Format(RP.V8,
                    src[0], src[1], src[2], src[3], src[4], src[5], src[6], src[7],
                    src[8], src[9]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v12<T> src)
            where T : unmanaged
                => ref @as<v12<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v12<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v16<T> v<T>(N16 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v16<T> v<T>(N16 n, v8<T> a0, v8<T> a1 = default)
            where T : unmanaged
        {
            var v = new v16<T>();
            ref var dst = ref @as<T,v8<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v16<T> src)
            where T : unmanaged
                => ref @as<v16<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v16<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v16<T> src)
            where T : unmanaged
                => string.Format(RP.V16,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],
                    src[8],  src[9],  src[10], src[11], src[12], src[13], src[14], src[15]
                    );

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v32<T> v<T>(N32 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v32<T> v<T>(N32 n, v16<T> a0, v16<T> a1 = default)
            where T : unmanaged
        {
            var v = new v32<T>();
            ref var dst = ref @as<T,v16<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v32<T> src)
            where T : unmanaged
                => ref @as<v32<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v32<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v32<T> src)
            where T : unmanaged
                => string.Format(RP.V32,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],  src[8], src[9],
                    src[10], src[11], src[12], src[13], src[14], src[15], src[16], src[17], src[18], src[19],
                    src[20], src[21], src[22], src[23], src[24], src[25], src[26], src[27], src[28], src[29],
                    src[30], src[31]
                    );

        /// <summary>
        /// Creates a vector of specifield length and parametric type
        /// </summary>
        /// <param name="n">The length selector</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v64<T> v<T>(N64 n)
            where T : unmanaged
                => default;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static v64<T> v<T>(N64 n, v32<T> a0, v32<T> a1 = default)
            where T : unmanaged
        {
            var v = new v64<T>();
            ref var dst = ref @as<T,v32<T>>(cell(ref v));
            seek(dst,0) = a0;
            seek(dst,1) = a1;
            return v;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T cell<T>(ref v64<T> src)
            where T : unmanaged
                => ref @as<v64<T>,T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> cells<T>(ref v64<T> src)
            where T : unmanaged
                => cover(cell(ref src), src.N);

        public static string format<T>(in v1<T> src)
            where T : unmanaged
                => string.Format(RP.V1, src[0]);

        public static string format<T>(in v64<T> src)
            where T : unmanaged
                => string.Format(RP.V64,
                    src[0],  src[1],  src[2],  src[3],  src[4],  src[5],  src[6],  src[7],  src[8], src[9],
                    src[10], src[11], src[12], src[13], src[14], src[15], src[16], src[17], src[18], src[19],
                    src[20], src[21], src[22], src[23], src[24], src[25], src[26], src[27], src[28], src[29],
                    src[30], src[31], src[32], src[33], src[34], src[35], src[36], src[37], src[38], src[39],
                    src[40], src[41], src[42], src[43], src[44], src[45], src[46], src[47], src[48], src[49],
                    src[50], src[51], src[52], src[53], src[54], src[55], src[56], src[57], src[58], src[59],
                    src[60], src[61], src[62], src[63]
                    );


        [MethodImpl(Inline), Op]
        public static vNx1<bool> v(N1 n, bool[] src)
            => new vNx1<bool>(src);

        [MethodImpl(Inline), Op]
        public static vNx1<byte> v(N1 n, byte[] src)
            => new vNx1<byte>(src);

        [MethodImpl(Inline), Op]
        public static vNx8<byte> v(N8 n, byte[] src)
            => new vNx8<byte>(src);

        [MethodImpl(Inline), Op]
        public static vNx16<ushort> v(N16 n, ushort[] src)
            => new vNx16<ushort>(src);

        [MethodImpl(Inline), Op]
        public static vNx64<ulong> v(N64 n, ulong[] src)
            => new vNx64<ulong>(src);

        [MethodImpl(Inline), Op]
        public static vNx64<MemoryAddress> v(N64 n, MemoryAddress[] src)
            => new vNx64<MemoryAddress>(src);

       [MethodImpl(Inline), Op]
        public static vNx32<uint> v(N32 n,  uint[] src)
            => new vNx32<uint>(src);

        [MethodImpl(Inline)]
        public static vector<N,T> v<N,T>(N n, T[] src)
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            if(Typed.nat32i<N>() != src.Length)
                return vector<N,T>.Empty;
            else
                return new vector<N,T>(src);
        }

        public static string format<N,T>(in vector<N,T> src)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var cells = src.Cells;
            var count = cells.Length;
            var buffer = text.buffer();
            var last = cells.Length - 1;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                var fmt = string.Format("{0}", cell).Trim();
                if(nonempty(fmt))
                {
                    buffer.Append(fmt);
                    if(i != last)
                        buffer.Append(Chars.Comma);

                }
                else
                    break;
            }
            return buffer.Emit();
        }

        [MethodImpl(Inline)]
        public static Outcome<uint> apply<S,T>(SeqProjector<S,T> p, ReadOnlySpan<S> src, Span<T> dst)
        {
            var count = (uint)min(src.Length,dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = p.F(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static DomainKey domain(uint kind, uint id)
            => new DomainKey(kind, id);

        [MethodImpl(Inline), Op]
        public static SourceKey source(DomainKey domain, uint id)
            => new SourceKey(domain,id);

        [MethodImpl(Inline), Op]
        public static TargetKey target(DomainKey domain, uint id)
            => new TargetKey(domain,id);

        [MethodImpl(Inline), Op]
        public static ProjectionKey projection(uint id, SourceKey src, TargetKey dst)
            => new ProjectionKey(id, src, dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DomainKey<D> domain<D>(D descriptor)
            where D : unmanaged
                => new DomainKey<D>(descriptor);

        [MethodImpl(Inline)]
        public static SeqProjector<S,T> projector<S,T>(Func<S,T> f)
            => new SeqProjector<S,T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SourceKey untype<T>(SourceKey<T> src, Func<SourceKey<T>,uint> f)
            => new SourceKey(src.Domain, f(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TargetKey untype<T>(TargetKey<T> src, Func<TargetKey<T>,uint> f)
            => new TargetKey(src.Domain, f(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SourceKey<T> source<T>(DomainKey d, T rep)
            => new SourceKey<T>(d,rep);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TargetKey<T> target<T>(DomainKey d, T rep)
            => new TargetKey<T>(d,rep);

        [MethodImpl(Inline)]
        public static ProjectionKey<S,T> projection<S,T>(uint id, SourceKey<T> src, TargetKey<T> dst)
            => new ProjectionKey<S,T>(id,src,dst);

        [MethodImpl(Inline)]
        public static ProjectionKey untype<S,T>(ProjectionKey<S,T> p, Func<SourceKey<T>,uint> f, Func<TargetKey<T>,uint> g)
        {
            var src = untype(p.Source,f);
            var dst = untype(p.Target,g);
            return new ProjectionKey(p.Id,src,dst);
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DomainKey untyped<D>(DomainKey<D> d)
            where D : unmanaged
        {
            var k = 0u;
            var i = 0u;
            var data = @readonly(bytes(d.Descriptor));
            if(size<D>() == 1)
            {
                ref readonly var b = ref skip(data,0);
                k = (uint)b & 0xF;
                i = (uint)b >> 4;
            }
            else if(size<D>() == 2)
            {
                k = skip(data,0);
                i = skip(data,1);
            }
            else if(size<D>() == 4)
            {
                k = skip16(data,0);
                i = skip16(data,2);
            }
            else if(size<D>() == 8)
            {
                k = skip32(data,0);
                i = skip32(data,4);
            }
            return new DomainKey(k,i);
        }


        /// <summary>
        /// Describes a domain, in 64 bits or less
        /// </summary>
        public readonly struct DomainKey<D>
            where D : unmanaged
        {
            public D Descriptor {get;}

            [MethodImpl(Inline)]
            public DomainKey(D d)
            {
                Descriptor = d;
            }

            [MethodImpl(Inline)]
            public static implicit operator DomainKey(DomainKey<D> src)
                => untyped(src);
        }

        /// <summary>
        /// Identifies a projection
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProjectionKey<S,T>
        {
            public SourceKey<T> Source {get;}

            public TargetKey<T> Target {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public ProjectionKey(uint id, SourceKey<T> src, TargetKey<T> dst)
            {
                Id = id;
                Source = src;
                Target = dst;
            }
        }

        /// <summary>
        /// A default projection effector
        /// </summary>
        public readonly struct SeqProjector<S,T> : ISeqProjector<S,T>
        {
            internal readonly Func<S,T> F;

            [MethodImpl(Inline)]
            internal SeqProjector(Func<S,T> f)
                => F = f;

            public Outcome<uint> Project(ReadOnlySpan<S> src, Span<T> dst)
                => apply(this,src,dst);
        }
    }
}