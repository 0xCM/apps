//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;

    using static Root;
    using static core;

    partial struct vcore
    {
        /// <summary>
        /// Creates a scalar vector from the lower 64 bits of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vlo<T>(Vector128<T> src)
            where T : unmanaged
                => generic<T>(vzerohi(v64u(src)));

        /// <summary>
        /// __m128i _mm_move_epi64 (__m128i a) MOVQ xmm, xmm
        /// Clears the high 64 bits of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vzerohi<T>(Vector128<T> src)
            where T : unmanaged
                => MoveScalar(v64u(src)).As<ulong,T>();

        /// <summary>
        /// Extracts the lo 128-bit lane of the source vector to scalar targets
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static void vlo<T>(Vector256<T> src, out ulong x0, out ulong x1)
            where T : unmanaged
                => vlo(v64u(src), out x0, out x1);

        /// <summary>
        /// Extracts the lo 128-bit lane of the source vector to a pair
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Closures(AllNumeric)]
        public static ref Pair<ulong> vlo<T>(Vector256<T> src, ref Pair<ulong> dst)
            where T : unmanaged
                => ref vlo(v64u(src), ref dst);

        /// <summary>
        /// Extracts the lower 256-bits from the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector256<T> vlo<T>(Vector512<T> src)
            where T : unmanaged
                => src.Lo;

        /// <summary>
        /// Extracts the lower 256-bits from the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Closures(AllNumeric)]
        public static Vector512<T> vlo<T>(Vector1024<T> src)
            where T : unmanaged
                => src.Lo;

        /// <summary>
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Vector128<T> vlo<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return vlo_u(src);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return vlo_i(src);
            else
                return vlo_f(src);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vlo_i<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(vlo(v8i(src)));
            else if(typeof(T) == typeof(short))
                return generic<T>(vlo(v16i(src)));
            else if(typeof(T) == typeof(int))
                return generic<T>(vlo(v32i(src)));
            else
                return generic<T>(vlo(v64i(src)));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vlo_u<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(vlo(v8u(src)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(vlo(v16u(src)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(vlo(v32u(src)));
            else
                return generic<T>(vlo(v64u(src)));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vlo_f<T>(Vector256<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(vlo(v32f(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(vlo(v64f(src)));
            else
                throw no<T>();
        }
    }
}