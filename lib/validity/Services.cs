//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static ICheckSF<T,T> UnaryOpMatch<T>(this ITestContext context, T t = default)
            where T : unmanaged
                => new CheckUnaryOpSF<T>(context);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T> UnaryOpMatch<T>(this ITestContext context, bool xzero, T t = default)
            where T : unmanaged
                => new CheckUnaryOpSF<T>(context, xzero);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,T> BinaryOpMatch<T>(this ITestContext context, T t = default)
            where T : unmanaged
                => new CheckBinaryOpSF<T>(context);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,T> BinaryOpMatch<T>(this ITestContext context, bool xzero, T t = default)
            where T : unmanaged
                => new CheckBinaryOpSF<T>(context,xzero);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,T,T> TernaryOpMatch<T>(this ITestContext context, bool xzero = false, T t = default)
            where T : unmanaged
                => new CheckTernaryOpSF<T>(context,xzero);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,bit> BinaryPredicateMatch<T>(this ITestContext context, T t = default)
            where T : unmanaged
                => new CheckBinaryPredSF<T>(context);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,bool> BinaryPredicateMatch8<T>(this ITestContext context, T t = default)
            where T : unmanaged
                => new CheckBinaryPredSF8<T>(context);

        [MethodImpl(Inline)]
        public static ICheckSF<T,T,T,bit> TernaryPredicateComparer<T>(this ITestContext context, T t = default)
            where T : unmanaged
                => new CheckTernaryPredSF<T>(context);
    }
}