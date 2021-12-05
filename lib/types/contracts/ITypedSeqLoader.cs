//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITypedSeqLoader<S,T>
        where S : IType
        where T : IType
    {
        Outcome Load(ITypedSeq<S> src, out T dst);
    }
}