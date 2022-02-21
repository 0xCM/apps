//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using static IntelDataTypes;

    using static core;

    partial struct Intrinsics
    {
        public readonly struct mm256_min_epu8 : IIntrinsicInput<mm256_min_epu8>
        {
            public readonly __m256i<byte> A;

            public readonly __m256i<byte> B;

            [MethodImpl(Inline)]
            public mm256_min_epu8(in __m256i<byte> a, in __m256i<byte> b)
            {
                A = a;
                B = b;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm256_min_epu8;
        }

        partial struct Refs
        {
            [MethodImpl(Inline)]
            public static __m256i<byte> calc(in mm256_min_epu8 src)
                => cpu.vmin(src.A,src.B);
        }

        partial struct Specs
        {
            [MethodImpl(Inline), Op]
            public static __m256i<byte> calc(in mm256_min_epu8 src)
                => mm256_min_epu8(src.A, src.B);

            [MethodImpl(Inline)]
            public static __m256i<byte> mm256_min_epu8(in __m256i<byte> a, in __m256i<byte> b)
            {
                var dst = m256i<byte>();
                for(var j=0; j<=31; j++)
                {
                    var i = j*8;
                    dst[i+7,i] = min(a[i+7,i], b[i+7,i]);
                }
                return dst;
            }
        }
    }
}