//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IActor
    {
        string Name {get;}
    }

    [Free]
    public interface IActor<A> : IActor
        where A : IActor
    {

    }
}