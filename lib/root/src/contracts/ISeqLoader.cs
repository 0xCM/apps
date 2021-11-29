//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISeqLoader<S,T>
    {
        Outcome Load(ReadOnlySpan<S> src, out T dst);
    }
}