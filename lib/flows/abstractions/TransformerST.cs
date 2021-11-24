//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;

    public abstract class Transformer<S,T>
    {
        public abstract ReadOnlySpan<T> Transform(ReadOnlySpan<S> src);
    }
}