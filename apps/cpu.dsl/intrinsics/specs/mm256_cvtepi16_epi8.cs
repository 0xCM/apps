//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;

    using static Root;
    using static core;

    partial struct Intrinsics
    {
        public readonly struct mm256_cvtepi16_epi8 : IIntrinsicInput<mm256_cvtepi16_epi8>
        {
            public readonly m256i<ushort> A;

            [MethodImpl(Inline)]
            public mm256_cvtepi16_epi8(in m256i<ushort> a)
            {
                A = a;
            }

            public IntrinsicKind Kind
                => IntrinsicKind._mm256_cvtepi16_epi8;
        }

        partial struct Specs
        {
            [MethodImpl(Inline)]
            public static m128i<byte> calc(in mm256_cvtepi16_epi8 src)
                => Specs.mm256_cvtepi16_epi8(src.A);

            [MethodImpl(Inline)]
            public static m128i<byte> mm256_cvtepi16_epi8(m256i<ushort> a)
            {
                var dst = m128i<byte>();
                for(var j=0; j<=15; j++)
                {
                    var i=16*j;
                    var l=8*j;
                    dst[l+7,l] = trunc8(a[i+15,i]);
                }

                return dst;
            }
        }

        [MethodImpl(Inline)]
        public static byte trunc8(ushort src)
            => (byte)src;

        [MethodImpl(Inline), Op]
        public static uint mm256_cvtepi16_epi8_loop(Span<v3<int>> dst)
        {
            var counter = 0u;
            for(var j=0; j<=15; j++)
            {
                var i=16*j;
                var l=8*j;
                seek(dst,j) = vectors.v(j, i, l);
                counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint _mm256_cvtepi16_epi8_seq(ReadOnlySpan<m256i<ushort>> src, Span<m128i<byte>> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = Specs.mm256_cvtepi16_epi8(skip(src,i));
            return count;
        }
    }
}