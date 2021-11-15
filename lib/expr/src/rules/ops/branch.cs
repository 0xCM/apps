//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;

    using Types;

    using static Root;

    partial struct rules
    {
        [MethodImpl(Inline)]
        public static Branch<K,T> branch<K,T>(Label name, Literal<K>[] choices, T[] targets)
            where K : unmanaged
            where T : IExpr
                => new Branch<K,T>(name, choices, targets);
    }
}