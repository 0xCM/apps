//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Link<L,S,T> : ILink<S,T>
        where L : Link<L, S, T>, new()
        where S : INode<S>, new()
        where T : INode<T>, new()
    {
        public S Source;

        public T Target;

        protected Link()
        {

        }

        protected Link(S src, T dst)
        {
            Source = src;
            Target = dst;
        }
        S ILink<S, T>.Source
            => Source;

        T ILink<S, T>.Target
            => Target;
    }
}