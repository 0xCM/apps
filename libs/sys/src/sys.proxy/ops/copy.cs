//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static System.Runtime.CompilerServices.Unsafe;

    using static ApiOpaqueClass;

    using O = ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(O.CopyBlock)]
        public static void copy(in byte src, ref byte dst, uint count)
            => CopyBlock(ref dst, ref AsRef(src), count);

        [MethodImpl(Options), Opaque(O.CopyBlock)]
        public static unsafe void copy(byte* pSrc, byte* pDst, uint count)
            => CopyBlock(pDst, pSrc, count);

        [MethodImpl(Options), Opaque(O.CopyBlock), Closures(Closure)]
        public static unsafe void copy<T>(T* pSrc, T* pDst, uint count)
            where T : unmanaged
                => CopyBlock(pDst, pSrc, count* (uint)SizeOf<T>());

        [MethodImpl(Options), Opaque(CopySpan), Closures(Closure)]
        public static ref readonly Span<T> copy<T>(ReadOnlySpan<T> src, in Span<T> dst)
        {
            src.CopyTo(dst);
            return ref dst;
        }
    }
}