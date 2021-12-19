//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActor : ITextual
    {
        Name Name {get;}

        string ITextual.Format()
            => Name;
    }

    public interface IActor<A>
        where A : IActor<A>
    {

    }
}