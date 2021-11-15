//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class NativeSegKinds
    {
        [MethodImpl(Inline)]
        public static NativeSegKind kind<W,T>(W w = default, T t = default)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
        {
            if(typeof(W) == typeof(W16))
                return kind<T>(default(W16));
            else if(typeof(W) == typeof(W32))
                return kind<T>(default(W32));
            else if(typeof(W) == typeof(W64))
                return kind<T>(default(W64));
            else if(typeof(W) == typeof(W128))
                return kind<T>(default(W128));
            else if(typeof(W) == typeof(W256))
                return kind<T>(default(W256));
            else if(typeof(W) == typeof(W512))
                return kind<T>(default(W512));
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W16 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W32 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W64 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W128 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W256 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        public static NativeSegKind kind<T>(W512 w, T t = default)
            where T : unmanaged
                => kind_u(w,t);

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W16 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg16x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg16x16u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W16 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg16x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg16x16i;
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W32 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg32x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg32x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg32x32u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W32 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg32x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg32x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg32x32i;
            else
                return kind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_f<T>(W32 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg32x32f;
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W64 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg64x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg64x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg64x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg64x64u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W64 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg64x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg64x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg64x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg64x64i;
            else
                return kind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_f<T>(W64 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg64x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg64x64f;
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W128 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg128x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg128x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg128x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg128x64u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W128 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg128x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg128x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg128x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg128x64i;
            else
                return kind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_f<T>(W128 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg128x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg128x64f;
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W256 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg256x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg256x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg256x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg256x64u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W256 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg256x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg256x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg256x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg256x64i;
            else
                return kind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_f<T>(W256 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg256x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg256x64f;
            else
                return NativeSegKind.None;
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_u<T>(W512 w, T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return NativeSegKind.Seg512x8u;
            else if(typeof(T) == typeof(ushort))
                return NativeSegKind.Seg512x16u;
            else if(typeof(T) == typeof(uint))
                return NativeSegKind.Seg512x32u;
            else if(typeof(T) == typeof(ulong))
                return NativeSegKind.Seg512x64u;
            else
                return kind_i(w,t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_i<T>(W512 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(sbyte))
                return NativeSegKind.Seg512x8i;
            else if(typeof(T) == typeof(short))
                return NativeSegKind.Seg512x16i;
            else if(typeof(T) == typeof(int))
                return NativeSegKind.Seg512x32i;
            else if(typeof(T) == typeof(long))
                return NativeSegKind.Seg512x64i;
            else
                return kind_f(w, t);
        }

        [MethodImpl(Inline)]
        static NativeSegKind kind_f<T>(W512 w, T t = default)
            where T : struct
        {
            if(typeof(T) == typeof(float))
                return NativeSegKind.Seg512x32f;
            else if(typeof(T) == typeof(double))
                return NativeSegKind.Seg512x64f;
            else
                return NativeSegKind.None;
        }
    }
}