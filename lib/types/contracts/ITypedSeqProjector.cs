//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITypedSeqProjector<S,T>
        where S : ITyped
        where T : ITyped
    {
        Outcome Map(ITypedSeq<S> src, ITypedSeq<T> dst);
    }
}