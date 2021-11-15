//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System;
    using System.Runtime.CompilerServices;

    using Z0.Lang;

    using static Root;

    partial struct Dfa
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DfaState<T> state<T>(int order, Atom<T> src)
            where T : unmanaged
                => new DfaState<T>(order, src);
    }
}