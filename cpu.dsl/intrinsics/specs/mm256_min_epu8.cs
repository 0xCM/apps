//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Intrinsics
    {
        public readonly struct mm256_min_epu8 : IIntrinsicInput<mm256_min_epu8>
        {
            public readonly m256i<byte> A;

            public readonly m256i<byte> B;

            [MethodImpl(Inline)]
            public mm256_min_epu8(in m256i<byte> a, in m256i<byte> b)
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
            public static m256i<byte> calc(in mm256_min_epu8 src)
                => cpu.vmin(src.A,src.B);
        }

        partial struct Specs
        {
            [MethodImpl(Inline), Op]
            public static m256i<byte> calc(in mm256_min_epu8 src)
                => mm256_min_epu8(src.A, src.B);

            [MethodImpl(Inline)]
            public static m256i<byte> mm256_min_epu8(in m256i<byte> a, in m256i<byte> b)
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