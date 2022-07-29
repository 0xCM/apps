//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using G = HashCodes.Generic;

    partial class Algs
    {
        [MethodImpl(Inline)]
        public static Hash32 hash<A,B>(A a, B b)
            where A : unmanaged
            where B : unmanaged
                => G.native(a) | G.native(b);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C>(A a, B b, C c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
                => G.native(a) | G.native(b) | G.native(c);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C,D>(A a, B b, C c, D d)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
                => G.native(a) | G.native(b) | G.native(c) | G.native(d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T src)
            => G.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y)
            => G.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y, T z)
            => G.hash(x, y, z, z);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T a, T b, T c, T d)
            => G.hash(a,b,c,d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(ReadOnlySpan<T> src)
            => G.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 native<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => HashCodes.native(src);
    }
}