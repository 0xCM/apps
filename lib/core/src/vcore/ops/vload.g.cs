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
    using static System.Runtime.Intrinsics.X86.Sse3;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static Root;
    using static core;

    partial struct vcore
    {
        /// <summary>
        /// Loads a 128-bit vector from a pointer-identified memory location
        /// </summary>
        /// <param name="pSrc">The source memory location</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector128<T> vload<T>(T* pSrc, out Vector128<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                vloadu_u(pSrc, out dst);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                vloadu_i(pSrc, out dst);
            else
                vloadu_f(pSrc, out dst);
            return ref dst;
        }

        /// <summary>
        /// Loads a 256-bit vector from a pointer-identified memory location
        /// </summary>
        /// <param name="pSrc">The source memory location</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector256<T> vload<T>(T* pSrc, out Vector256<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                vloadu_u(pSrc, out dst);
            else if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                vloadu_i(pSrc, out dst);
            else
                vloadu_f(pSrc, out dst);

            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector512<T> vload<T>(T* pSrc, out Vector512<T> dst)
            where T : unmanaged
        {
            vload(pSrc, out Vector256<T> a);
            vload((T*)Unsafe.Add<T>(pSrc, Vector256<T>.Count), out Vector256<T> b);
            dst = new Vector512<T>(a,b);
            return ref dst;
        }

        /// <summary>
        /// Loads a 128-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector128<T> vload<T>(W128 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector128<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector256<T> vload<T>(W256 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector256<T> _);

        /// <summary>
        /// Loads a 512-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector512<T> vload<T>(W512 w, in T src)
            where T : unmanaged
                => vload(gptr(src), out Vector512<T> _);

        /// <summary>
        /// Loads a 128-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector128<T> vload<T>(W128 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector128<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector256<T> vload<T>(W256 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector256<T> _);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference offset by a cell-relative offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The memory reference</param>
        /// <param name="offset">The memory reference</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe Vector512<T> vload<T>(W512 w, in T src, int offset)
            where T : unmanaged
                => vload(gptr(src, offset), out Vector512<T> _);

        /// <summary>
        /// Loads a 128-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector128<T> vload<T>(in T src, out Vector128<T> dst)
            where T : unmanaged
                => ref vload(gptr(src), out dst);

        /// <summary>
        /// Loads a 256-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector256<T> vload<T>(in T src, out Vector256<T> dst)
            where T : unmanaged
                => ref vload(gptr(src), out dst);

        /// <summary>
        /// Loads a 512-bit vector from a readonly memory reference
        /// </summary>
        /// <param name="src">The memory reference</param>
        /// <param name="dst">The target vector</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref Vector512<T> vload<T>(in T src, out Vector512<T> dst)
            where T : unmanaged
                => ref vload(gptr(src), out dst);

        /// <summary>
        /// Loads a 128-bit vector from the first 128 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector from the first 128 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(W256 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 512-bit vector from the first 512 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(W512 w, Span<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(W128 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(W256 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, Span<T> src, int offset)
            where T : unmanaged
                => vload(w, seek(src, (uint)offset));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(N256 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 256-bit vector from the first 256 bits of the source
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vload(w, first(src));

        /// <summary>
        /// Loads a 128-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector128<T> vload<T>(N128 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));

        /// <summary>
        /// Loads a 256-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector256<T> vload<T>(N256 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));

        /// <summary>
        /// Loads a 512-bit vector beginning at a specified source cell offset
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="src">The source span</param>
        /// <param name="offset">The position of the fist source element </param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vector512<T> vload<T>(N512 w, ReadOnlySpan<T> src, int offset)
            where T : unmanaged
                => vload(w, skip(src, offset));

        [MethodImpl(Inline)]
        static unsafe void vloadu_u<T>(T* pSrc, out Vector128<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst = generic<T>(LoadDquVector128((byte*)pSrc));
            else if(typeof(T) == typeof(ushort))
                dst = generic<T>(LoadDquVector128((ushort*)pSrc));
            else if(typeof(T) == typeof(uint))
                dst = generic<T>(LoadDquVector128((uint*)pSrc));
            else
                dst = generic<T>(LoadDquVector128((ulong*)pSrc));

        }

        [MethodImpl(Inline)]
        static unsafe void vloadu_i<T>(T* pSrc, out Vector128<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                dst = generic<T>(LoadDquVector128((sbyte*)pSrc));
            else if(typeof(T) == typeof(short))
                dst = generic<T>(LoadDquVector128((short*)pSrc));
            else if(typeof(T) == typeof(int))
                dst = generic<T>(LoadDquVector128((int*)pSrc));
            else
                dst = generic<T>(LoadDquVector128((long*)pSrc));
        }

        [MethodImpl(Inline)]
        static unsafe void vloadu_f<T>(T* pSrc, out Vector128<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                dst = generic<T>(LoadVector128((float*)pSrc));
            else if(typeof(T) == typeof(double))
                dst = generic<T>(LoadVector128((double*)pSrc));
            else
                throw no<T>();
        }

        [MethodImpl(Inline)]
        static unsafe void vloadu_u<T>(T* pSrc, out Vector256<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                dst = generic<T>(LoadDquVector256((byte*)pSrc));
            else if(typeof(T) == typeof(ushort))
                dst = generic<T>(LoadDquVector256((ushort*)pSrc));
            else if(typeof(T) == typeof(uint))
                dst = generic<T>(LoadDquVector256((uint*)pSrc));
            else
                dst = generic<T>(LoadDquVector256((ulong*)pSrc));
        }

        [MethodImpl(Inline)]
        static unsafe void vloadu_i<T>(T* pSrc, out Vector256<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                dst = generic<T>(LoadDquVector256((sbyte*)pSrc));
            else if(typeof(T) == typeof(short))
                dst = generic<T>(LoadDquVector256((short*)pSrc));
            else if(typeof(T) == typeof(int))
                dst = generic<T>(LoadDquVector256((int*)pSrc));
            else
                dst = generic<T>(LoadDquVector256((long*)pSrc));
        }

        [MethodImpl(Inline)]
        static unsafe void vloadu_f<T>(T* pSrc, out Vector256<T> dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                dst = generic<T>(LoadVector256((float*)pSrc));
            else if(typeof(T) == typeof(double))
                dst = generic<T>(LoadVector256((double*)pSrc));
            else
                throw no<T>();
        }
    }
}