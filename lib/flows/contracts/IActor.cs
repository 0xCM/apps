//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActor : IType
    {
        string ITextual.Format()
            => Name;
    }

    public interface IActor<A> : IActor
        where A : IActor<A>
    {

    }
}