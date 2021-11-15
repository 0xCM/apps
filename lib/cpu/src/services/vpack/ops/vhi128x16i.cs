//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse41;
    using static Root;
    using static cpu;

    partial struct vpack
    {
        /// <summary>
        /// __m128i _mm_cvtepi8_epi16 (__m128i a)
        /// PMOVSXBW xmm, xmm/m64
        /// 8x8i -> 8x16i
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="wDst">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vhi128x16i(Vector128<sbyte> src)
            => ConvertToVector128Int16(vshi(src));
    }
}