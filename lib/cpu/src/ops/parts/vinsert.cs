//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Sse41.X64;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_insert_epi8 (__m128i a, int i, const int imm8) PINSRB xmm, reg/m8, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vinsert(byte src, Vector128<byte> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        ///  __m128i _mm_insert_epi8 (__m128i a, int i, const int imm8) PINSRB xmm, reg/m8, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vinsert(sbyte src, Vector128<sbyte> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi16 (__m128i a, int i, int immediate) PINSRW xmm, reg/m16, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vinsert(short src, Vector128<short> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi16 (__m128i a, int i, int immediate) PINSRW xmm, reg/m16, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vinsert(ushort src, Vector128<ushort> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi32 (__m128i a, int i, const int imm8) PINSRD xmm, reg/m32, xmm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vinsert(int src, Vector128<int> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi32 (__m128i a, int i, const int imm8) PINSRD xmm, reg/m32, xmm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vinsert(uint src, Vector128<uint> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi64 (__m128i a, __int64 i, const int imm8) PINSRQ xmm, reg/m64,imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vinsert(long src, Vector128<long> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        /// __m128i _mm_insert_epi64 (__m128i a, __int64 i, const int imm8) PINSRQ xmm, reg/m64, imm8
        /// Overwrites an identified component in the target vector with a specified value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">The 0-based index of the component to overwrite</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vinsert(ulong src, Vector128<ulong> dst, [Imm] byte index)
            => Insert(dst, src, index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vinsert(Vector128<sbyte> src, Vector256<sbyte> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vinsert(Vector128<byte> src, Vector256<byte> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vinsert(Vector128<short> src, Vector256<short> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinsert(Vector128<ushort> src, Vector256<ushort> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vinsert(Vector128<int> src, Vector256<int> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vinsert(Vector128<uint> src, Vector256<uint> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vinsert(Vector128<long> src, Vector256<long> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vinsert(Vector128<ulong> src, Vector256<ulong> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        /// _mm256_insertf128_ps: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vinsert(Vector128<float> src, Vector256<float> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vinsert(Vector128<double> src, Vector256<double> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);
    }
}