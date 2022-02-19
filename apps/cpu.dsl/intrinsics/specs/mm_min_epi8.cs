//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using Asm.Operands;

    using static core;

    partial struct Intrinsics
    {
        public readonly struct mm_min_epi8 : IIntrinsicInput<mm_min_epi8>
        {
            public readonly __m128i<sbyte> A;

            public readonly __m128i<sbyte> B;

            [MethodImpl(Inline)]
            public mm_min_epi8(in __m128i<sbyte> a, in __m128i<sbyte> b)
            {
                A = a;
                B = b;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_min_epi8;
        }

        partial struct Specs
        {
            [MethodImpl(Inline)]
            public static __m128i<sbyte> calc(in mm_min_epi8 src)
                => mm_min_epi8(src.A, src.B);

            [MethodImpl(Inline)]
            public static __m128i<sbyte> mm_min_epi8(in __m128i<sbyte> a, in __m128i<sbyte> b)
            {
                var dst = m128i<sbyte>();
                for(var j=0; j<=15; j++)
                {
                    var i = j*8;
                    dst[i+7,i] = min(a[i+7,i], b[i+7,i]);
                }
                return dst;
            }
        }
    }
}
