//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    using Contracts;

    /// <summary>
    /// Defines a reference to an entity
    /// </summary>
    /// <typeparam name="R">The concrete reference type</typeparam>
    /// <typeparam name="E">The concrete entity type</typeparam>
    public abstract record class EntityRef<R,E> : ModelRef<R,E>
        where R : ModelRef<R,E>,new()
        where E : IEntity<E>, INode<E>, new()
    {

    }
}