//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISeqAggregator<S,T>
    {
        Outcome Distill(ReadOnlySpan<S> src, out T dst);
    }
}