//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface INode<V> : IModel
    {
        V Value {get;}
    }
}