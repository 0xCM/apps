//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Intrinsics
    {
        public readonly struct mm_avg_epu8 : IIntrinsicInput<mm_avg_epu8>
        {
            public readonly m128i<byte> A;

            public readonly m128i<byte> B;

            [MethodImpl(Inline)]
            public mm_avg_epu8(in m128i<byte> a, in m128i<byte> b)
            {
                A = a;
                B = b;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_avg_epu8;
        }

        partial struct Specs
        {
            [MethodImpl(Inline)]
            public static m128i<byte> calc(in mm_avg_epu8 src)
                => mm_avg_epu8(src.A, src.B);

            [MethodImpl(Inline)]
            public static m128i<byte> mm_avg_epu8(in m128i<byte> a, in m128i<byte> b)
            {
                var dst = m128i<byte>();
                var i = 0;
                for(var j=0; j<=15; j++)
                {
                    i = j*8;
                    dst[i + 7,i] = (byte)((a[i+7,i] + b[i+7,i]) >> 1);
                }

                return dst;
            }
        }
    }
}