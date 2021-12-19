//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IActor : IType
    {
        string ITextual.Format()
            => Name;
    }

    public interface IActor<A> : IActor
        where A : IActor<A>
    {

    }

    public interface IActor<A,K> : IActor<A>
        where A : IActor<A,K>
    {
        ReadOnlySpan<K> Capabilities {get;}
    }
}