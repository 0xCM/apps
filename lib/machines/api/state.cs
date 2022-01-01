//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Dfa
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DfaState<T> state<T>(uint key, T src)
            where T : unmanaged
                => new DfaState<T>(key, src);
    }
}