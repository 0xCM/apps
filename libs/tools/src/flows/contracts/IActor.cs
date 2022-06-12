//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActor
    {
        Identifier Name {get;}
    }

    public interface IActor<A> : IActor
        where A : IActor
    {

    }
}