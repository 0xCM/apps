//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Abstractions;

    public sealed record class Link<S,T> : Link<Link<S,T>,S,T>
        where S : INode<S>, new()
        where T : INode<T>, new()
    {
        public Link()
        {

        }

        public Link(S src, T dst)
            : base(src,dst)
        {

        }
    }
}