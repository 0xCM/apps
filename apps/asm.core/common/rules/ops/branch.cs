//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Rules
    {
        [MethodImpl(Inline)]
        public static BranchRule<K,T> branch<K,T>(Label name, Literal<K>[] choices, T[] targets)
            where K : unmanaged
            where T : IExpr
                => new BranchRule<K,T>(name, choices, targets);
    }
}