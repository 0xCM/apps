//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using Asm;
    using Asm.Operands;

    partial struct Intrinsics
    {
        public readonly struct mm_blend_epi32 : IIntrinsicInput<mm_blend_epi32>
        {
            public readonly __m128i<uint> A;

            public readonly __m128i<uint> B;

            public readonly imm8 Imm8;

            [MethodImpl(Inline)]
            public mm_blend_epi32(in __m128i<uint> a, in __m128i<uint> b, imm8 imm8)
            {
                A = a;
                B = b;
                Imm8 = imm8;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_blend_epi32;
        }

        partial struct Specs
        {
            [MethodImpl(Inline)]
            public static __m128i<uint> calc(in mm_blend_epi32 src)
                => Specs.mm_blend_epi32(src.A, src.B, src.Imm8);

            [MethodImpl(Inline)]
            public static __m128i<uint> mm_blend_epi32(in __m128i<uint> a, in __m128i<uint> b, imm8 imm8)
            {
                var dst = m128i<uint>();
                var i=0;
                for(var j=0; j<=3; j++)
                {
                    i = j*32;
                    if(imm8[i])
                        dst[i+31,i] = b[i+31,i];
                    else
                        dst[i+31,i] = a[i+31,i];
                }

                return dst;
            }
        }
    }
}