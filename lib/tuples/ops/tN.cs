//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class Tuples
    {
        [MethodImpl(Inline)]
        public static tuple<T0> t1<T0>(T0 a0 = default)
            where T0: IEquatable<T0>
                => new tuple<T0>(a0);

        [MethodImpl(Inline)]
        public static tuple<T0,T1> t2<T0,T1>(T0 a0 = default, T1 a1 = default)
            where T0: IEquatable<T0>
            where T1: IEquatable<T1>
                => new tuple<T0,T1>(a0,a1);

        [MethodImpl(Inline)]
        public static tuple<T0,T1,T2> t3<T0,T1,T2>(T0 a0 = default, T1 a1 = default, T2 a2 = default)
            where T0: IEquatable<T0>
            where T1: IEquatable<T1>
            where T2: IEquatable<T2>
                => new tuple<T0,T1,T2>(a0,a1,a2);


        [MethodImpl(Inline)]
        public static tuple<T0,T1,T2,T3> t4<T0,T1,T2,T3>(T0 a0 = default, T1 a1 = default, T2 a2 = default, T3 a3 = default)
            where T0: IEquatable<T0>
            where T1: IEquatable<T1>
            where T2: IEquatable<T2>
            where T3: IEquatable<T3>
                => new tuple<T0,T1,T2,T3>(a0,a1,a2,a3);
    }
}