//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    // public sealed class EquatableChecker : Checker<EquatableChecker,IEquatableChecker>, IEquatableChecker
    // {
    //     [MethodImpl(Inline)]
    //     public CheckResult Eq<T>(T lhs, T rhs)
    //         where T : IEquatable<T>
    //     {
    //         var passed = lhs.Equals(rhs);
    //         return new CheckResult(ClaimKind.Eq, Operation, root.index((dynamic)lhs, (dynamic)rhs), passed);
    //     }
    // }
}