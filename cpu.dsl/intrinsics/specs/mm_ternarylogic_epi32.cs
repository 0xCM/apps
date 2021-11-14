//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BitNumbers;

    partial struct Intrinsics
    {
        public struct mm_ternarylogic_epi32 : IIntrinsicInput<mm_ternarylogic_epi32>
        {
            public m128i<uint> A;

            public m128i<uint> B;

            public m128i<uint> C;

            public Imm8 Imm8;

            [MethodImpl(Inline)]
            public mm_ternarylogic_epi32(m128i<uint> a, m128i<uint> b, m128i<uint> c, Imm8 imm8)
            {
                A = a;
                B = b;
                C = c;
                Imm8 = imm8;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_ternarylogic_epi32;
        }

        partial struct Specs
        {
            [MethodImpl(Inline)]
            public static m128i<uint> calc(in mm_ternarylogic_epi32 src)
                => Specs.mm_ternarylogic_epi32(src.A, src.B, src.C, src.Imm8);

            /// <summary>
            /// __m128i _mm_ternarylogic_epi32(__m128i a, __m128i b, __m128i c, int imm8)
            /// VPTERNLOGD xmm, xmm, xmm, imm8
            /// Bitwise ternary logic that provides the capability to implement any three-operand binary function;
            /// the specific binary function is specified by value in "imm8". For each bit in each packed 32-bit integer,
            /// the corresponding bit from "a", "b", and "c" are used to form a 3 bit index into "imm8", and the value at
            /// that bit in "imm8" is written to the corresponding bit in "dst".
            /// </summary>
            [MethodImpl(Inline)]
            public static m128i<uint> mm_ternarylogic_epi32(m128i<uint> a, m128i<uint> b, m128i<uint> c, Imm8 imm8)
            {
                var dst = m128i<uint>();
                for(byte j=0; j<=3; j++)
                {
                    var i = j*32;
                    for(byte h=0; h<=31; h++)
                    {
                        var index = join(c[i+h], b[i+h], a[i+h]);
                        dst[i + h] = imm8[index];
                    }
                }
                return dst;
            }
        }
    }
}