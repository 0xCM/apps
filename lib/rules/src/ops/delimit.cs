//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Delimit<T> delimit<T>(T marker)
            where T : IEquatable<T>
                => marker;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static PairDelimit<T> delimit<T>(T left, T right)
            where T : IEquatable<T>
                => (left,right);
    }
}