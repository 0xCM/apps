//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HashCodes.Generic;

    partial class Algs
    {
        [MethodImpl(Inline)]
        public static Hash32 hash<A,B>(A a, B b)
            where A : unmanaged
            where B : unmanaged
                => native(a) | native(b);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C>(A a, B b, C c)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
                => native(a) | native(b) | native(c);

        [MethodImpl(Inline)]
        public static Hash32 hash<A,B,C,D>(A a, B b, C c, D d)
            where A : unmanaged
            where B : unmanaged
            where C : unmanaged
            where D : unmanaged
                => native(a) | native(b) | native(c) | native(d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T src)
            => hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y)
            => combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y, T z)
            => hash(x, y, z, z);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T a, T b, T c, T d)
            => hash(a,b,c,d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(ReadOnlySpan<T> src)
            => hash(src);
    }
}