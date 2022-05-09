//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {

        [MethodImpl(Inline)]
        public static Points<X0,X1,T> points<X0,X1,T>(Dim<X0,X1,T> dim, T[] values)
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where T : unmanaged
                =>  @as<T[],Points<X0,X1,T>>(values);

        [MethodImpl(Inline)]
        public static Points<X0,X1,X2,T> points<X0,X1,X2,T>(Dim<X0,X1,X2,T> dim, T[] values)
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where X2 : unmanaged, ITypeNat
            where T : unmanaged
                =>  @as<T[],Points<X0,X1,X2,T>>(values);

    }
}