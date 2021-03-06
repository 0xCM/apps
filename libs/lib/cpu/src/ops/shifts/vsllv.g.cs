//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    partial struct gcpu
    {
        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..n-1 for vectors of length n
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv, Closures(Integers)]
        public static Vector128<T> vsllv<T>(Vector128<T> x, Vector128<T> counts)
            where T : unmanaged
                => vsllv_u(x, counts);

        /// <summary>
        /// Computes z[i] := x[i] << s[i] for i = 0..n-1 for vectors of length n
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="counts">The offset vector</param>
        [MethodImpl(Inline), Sllv, Closures(Integers)]
        public static Vector256<T> vsllv<T>(Vector256<T> x, Vector256<T> counts)
            where T : unmanaged
                => vsllv_u(x,counts);

        [MethodImpl(Inline)]
        static Vector128<T> vsllv_u<T>(Vector128<T> x, Vector128<T> counts)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vsllv(v8u(x), v8u(counts)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vsllv(v16u(x), v16u(counts)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vsllv(v32u(x), v32u(counts)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vsllv(v64u(x), v64u(counts)));
            else
                return vsllv_i(x,counts);
        }

        [MethodImpl(Inline)]
        static Vector128<T> vsllv_i<T>(Vector128<T> x, Vector128<T> counts)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vsllv(v8i(x), v8i(counts)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vsllv(v16i(x), v16i(counts)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vsllv(v32i(x), v32i(counts)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vsllv(v64i(x), v64i(counts)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsllv_u<T>(Vector256<T> x, Vector256<T> counts)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(cpu.vsllv(v8u(x), v8u(counts)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(cpu.vsllv(v16u(x), v16u(counts)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(cpu.vsllv(v32u(x), v32u(counts)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(cpu.vsllv(v64u(x), v64u(counts)));
            else
                return vsllv_i(x,counts);
        }

        [MethodImpl(Inline)]
        static Vector256<T> vsllv_i<T>(Vector256<T> x, Vector256<T> counts)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return generic<T>(cpu.vsllv(v8i(x), v8i(counts)));
            else if(typeof(T) == typeof(short))
                return generic<T>(cpu.vsllv(v16i(x), v16i(counts)));
            else if(typeof(T) == typeof(int))
                return generic<T>(cpu.vsllv(v32i(x), v32i(counts)));
            else if(typeof(T) == typeof(long))
                return generic<T>(cpu.vsllv(v64i(x), v64i(counts)));
            else
                throw no<T>();
        }
    }
}