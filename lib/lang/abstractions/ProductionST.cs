//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Production<S,T> : IProduction<S,T>
        where S : IExpr
        where T : IExpr
    {
        public abstract ReadOnlySpan<T> Terms(S src);
    }
}