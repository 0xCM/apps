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
        public readonly struct mm_delta_epu8 : IIntrinsicInput<mm_delta_epu8>
        {
            public readonly m128i<byte> A;

            public readonly m128i<byte> B;

            [MethodImpl(Inline)]
            public mm_delta_epu8(in m128i<byte> a, in m128i<byte> b)
            {
                A = a;
                B = b;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_avg_epu8;
        }

        [MethodImpl(Inline)]
        public static m128i<byte> calc(in mm_delta_epu8 src)
            => cpu.vor(cpu.vsubs(src.A, src.B), cpu.vsubs(src.B, src.A));
    }
}