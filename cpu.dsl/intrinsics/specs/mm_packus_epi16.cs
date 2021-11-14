//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static math;

    partial struct Intrinsics
    {
        public struct mm_packus_epi16
        {
            public m128i<short> A;

            public m128i<short> B;

            [MethodImpl(Inline)]
            public mm_packus_epi16(in m128i<short> a, in m128i<short> b)
            {
                A = a;
                B = b;
            }

            public IntrinsicKind Kind
                => IntrinsicKind.mm_packus_epi16;
        }

        partial struct Specs
        {
            [MethodImpl(Inline), Op]
            public static m128i<byte> calc(in mm_packus_epi16 io)
                => Specs.mm_packus_epi16(io.A, io.B);

            [MethodImpl(Inline)]
            public static m128i<byte> mm_packus_epi16(in m128i<short> a, in m128i<short> b)
            {
                var dst = m128i<byte>();
                dst[7,0] = sat8u(a[15,0]);
                dst[15,8] = sat8u(a[31,16]);
                dst[23,16] = sat8u(a[47,32]);
                dst[31,24] = sat8u(a[63,48]);
                dst[39,32] = sat8u(a[79,64]);
                dst[47,40] = sat8u(a[95,80]);
                dst[55,48] = sat8u(a[111,96]);
                dst[63,56] = sat8u(a[127,112]);
                dst[71,64] = sat8u(b[15,0]);
                dst[79,72] = sat8u(b[31,16]);
                dst[87,80] = sat8u(b[47,32]);
                dst[95,88] = sat8u(b[63,48]);
                dst[103,96] = sat8u(b[79,64]);
                dst[111,104] = sat8u(b[95,80]);
                dst[119,112] = sat8u(b[111,96]);
                dst[127,120] = sat8u(b[127,112]);
                return dst;
            }
        }
    }
}