//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static intel;
    using static IntelIntrinsics.Defs;

    partial class IntelIntrinsics
    {
        [ApiHost(refs)]
        public class Refs
        {
            [MethodImpl(Inline), Op]
            public static __m128i<byte> calc(in mm_delta_epu8 src)
                => cpu.vor(cpu.vsubs(src.A, src.B), cpu.vsubs(src.B, src.A));

            [MethodImpl(Inline), Op]
            public static __m256i<byte> calc(in mm256_min_epu8 src)
                => cpu.vmin(src.A,src.B);
        }
    }
}