//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static cpu;

    partial class PolyBits
    {
        /// <summary>
        /// 4x16u -> 4x32u
        /// __m128i _mm_cvtepu16_epi32 (__m128i a)
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// PMOVZXWD xmm, xmm/m64
        /// PMOVZXWD_XMMdq_XMMq
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> pmovzxwd(Vector128<ushort> src, out Vector128<uint> dst)
            => dst = v32u(ConvertToVector128Int32(src));

        /// <summary>
        /// 4x16u -> 4x32u
        /// __m128i _mm_cvtepu16_epi32 (__m128i a)
        /// movzx(src[i]) -> dst[i], i = 0,..,3
        /// PMOVZXWD xmm, xmm/m64
        /// PMOVZXWD_XMMdq_XMMq
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> pmovzxwd(num64 src, out Vector128<uint> dst)
            => dst = v32u(ConvertToVector128Int32(gcpu.vload<ushort>(w128, src.Bytes)));

    }
}