//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISeqProjector<S,T>
        where S : IType
        where T : IType
    {
        Outcome Map(ISeq<S> src, ISeq<T> dst);
    }
}