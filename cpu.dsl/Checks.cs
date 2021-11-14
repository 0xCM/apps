//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;

    using static core;
    using static Root;

    partial struct Intrinsics
    {
        [ApiComplete("intrinsics.specs")]
        public readonly partial struct Specs
        {


        }

        [ApiComplete("intrinsics.refs")]
        public readonly partial struct Refs
        {

        }

        [ApiHost("intrinsics.checks")]
        public partial class Checks : Service<Checks>
        {
            [MethodImpl(Inline)]
            public static CmpPred128<T> eq<T>(m128i<T> a, m128i<T> b)
                where T : unmanaged
                    => new CmpPred128<T>(CmpPredKind.EQ,a,b);

            readonly PageBank16x4x4 Buffer;

            readonly IPolyrand Random;

            public Checks()
            {
                Buffer = PageBank16x4x4.allocated();
                Random = Rng.wyhash64(PolySeed64.lookup(5));
            }

            public ref readonly PageBankInfo BufferInfo
                => ref Buffer.Describe();

            [MethodImpl(Inline), Op, Closures(Closure)]
            Span<T> Cells<T>(N0 n)
                where T : unmanaged
                    => Buffer.Block(n).Cells<T>();

            [MethodImpl(Inline)]
            Span<T> Cells<T>(N1 n)
                where T : unmanaged
                    => Buffer.Block(n).Cells<T>();

            [MethodImpl(Inline)]
            Span<T> Cells<T>(N2 n)
                where T : unmanaged
                    => Buffer.Block(n).Cells<T>();

            [MethodImpl(Inline), Op, Closures(Closure)]
            Span<m128i<T>> Vecs<T>(N0 n, W128 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m128i<T>>();

            [MethodImpl(Inline)]
            Span<m256i<T>> Vecs<T>(N0 n, W256 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m256i<T>>();

            [MethodImpl(Inline)]
            Span<m512i<T>> Vecs<T>(N0 n, W512 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m512i<T>>();

            [MethodImpl(Inline)]
            Span<m128i<T>> Vecs<T>(N1 n, W128 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m128i<T>>();

            [MethodImpl(Inline)]
            Span<m256i<T>> Vecs<T>(N1 n, W256 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m256i<T>>();

            [MethodImpl(Inline)]
            Span<m512i<T>> Vecs<T>(N1 n, W512 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m512i<T>>();

            [MethodImpl(Inline)]
            Span<m128i<T>> Vecs<T>(N2 n, W128 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m128i<T>>();

            [MethodImpl(Inline)]
            Span<m256i<T>> Vecs<T>(N2 n, W256 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m256i<T>>();

            [MethodImpl(Inline)]
            Span<m512i<T>> Vecs<T>(N2 n, W512 w)
                where T : unmanaged
                    => Buffer.Block(n).Cells<m512i<T>>();

            void Segments()
            {
                var src = Vecs<byte>(n0,w128);
                src.Clear();
                var count = src.Length;
                for(var i=0; i<count; i++)
                {
                    ref var vec = ref seek(src,i);
                    var bits = vec.Width;
                    for(byte j=0; j<bits; j+=8)
                        vec[j+7,j] = (byte)(j/8);
                    Write(string.Format("{0:D5}:{1}", i, vec.Format()));
                }
            }

            void Loops()
            {
                var src = Cells<int>(n2);
                var loops = recover<int,v3<int>>(src);
                var count = mm256_cvtepi16_epi8_loop(loops);
                for(var i=0; i<count; i++)
                {
                    ref readonly var loop = ref skip(loops,i);
                    Write(loop.Format());
                }
            }

            [Op]
            void Compute()
            {
                var block0 = Cells<ushort>(n0);
                var block1 = Cells<byte>(n1);
                var block2 = Cells<int>(n2);
                Random.Fill(block0);
                block1.Clear();

                var src = recover<m256i<ushort>>(block0);
                var dst = recover<m128i<byte>>(block1);
                var count = _mm256_cvtepi16_epi8_seq(src,dst);
                var op = nameof(_mm256_cvtepi16_epi8_seq);
                for(var i=0; i<count; i++)
                {
                    ref readonly var a = ref skip(src,i);
                    ref readonly var x = ref skip(dst,i);
                    var expr = string.Format("{0}:{1} -> {2}", op, a , x);
                    Write(expr);
                }
            }

            public void Run()
            {
                Compute(IntrinsicKind.mm256_min_epu8);
                Compute(IntrinsicKind.mm_packus_epi16);
                Compute(IntrinsicKind.mm_min_epi8);
            }
        }
    }
}
