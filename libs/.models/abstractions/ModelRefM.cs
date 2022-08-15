//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    using Contracts;

    /// <summary>
    /// Defines a reference to a model
    /// </summary>
    /// <typeparam name="R">The concrete reference type</typeparam>
    /// <typeparam name="M">The concrete model type</typeparam>
    public abstract record class ModelRef<R,M> : Link<R,M,M>
        where R : ModelRef<R,M>,new()
        where M : INode<M>, new()
    {

    }
}