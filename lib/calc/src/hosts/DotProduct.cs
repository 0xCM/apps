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

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(Integers)]
        public readonly struct DotProduct<T> : IFunc<T,T,bit>
            where T : unmanaged
        {
            public static DotProduct<T> Op => default;

            public const string Name = "dot";

            public OpIdentity Id
                => SFxIdentity.identity<T>(Name);

            [MethodImpl(Inline)]
            public bit Invoke(T a, T b)
                => gbits.dot(a,b);
        }

        [Closures(UnsignedInts), Dot]
        public readonly struct BvDotProduct<T> : IBvBinaryPred<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly bit Invoke(BitVector<T> a, BitVector<T> b)
                => BitVector.dot(a,b);

            [MethodImpl(Inline)]
            public bit Invoke(T a, T b)
                => gbits.dot(a,b);
        }
    }
}