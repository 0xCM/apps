//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct Arrays
    {
        public static Z[] flat<N,T,Y,Z>(Array<N,T> src, Func<T,Array<N,Y>> lift, Func<T,Y,Z> project)
            where N : unmanaged, ITypeNat
                => array(
                        from x in src.Storage
                        from y in lift(x).Storage
                        select project(x, y)
                    );

        public static Y[] flat<N,T,Y>(Array<N,T> src, Func<T,Array<N,Y>> lift)
            where N : unmanaged, ITypeNat
            => array(from x in src.Storage
                from y in lift(x).Storage
                select y);
    }
}