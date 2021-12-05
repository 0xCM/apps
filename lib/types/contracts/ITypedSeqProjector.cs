//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITypedSeqProjector<S,T>
        where S : IType
        where T : IType
    {
        Outcome Map(ITypedSeq<S> src, ITypedSeq<T> dst);
    }
}