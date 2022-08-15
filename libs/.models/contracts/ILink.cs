//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface ILink : IModel
    {

    }

    public interface ILink<S,T> : ILink
        where S : INode<S>, new()
        where T : INode<T>, new()
    {
        S Source {get;}

        T Target {get;}
    }
}