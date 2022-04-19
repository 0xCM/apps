//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Seq
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Seq<T> define<T>(params T[] src)
            where T : IEquatable<T>
                => src;

        public static Seq<N,T> define<N,T>(N n, params T[] src)
            where T : IEquatable<T>
            where N : unmanaged, ITypeNat
        {
            Require.equal(src.Length,n);
            return new Seq<N,T>(src);
        }
    }
}