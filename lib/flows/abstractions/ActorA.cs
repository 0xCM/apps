//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Actor]
    public abstract class Actor<A> : Actor, IActor<A>
        where A : Actor<A>,new()
    {
        protected Actor(Identifier name)
            : base(name)
        {

        }
    }
}