//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public abstract class Production<S,T> : IProduction<S,T>
        where S : IExpr
        where T : IExpr
    {
        public abstract ReadOnlySpan<T> Terms(S src);
    }
}