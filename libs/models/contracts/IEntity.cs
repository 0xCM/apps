//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface IEntity : IModel
    {
        string Name {get;}
    }

    public interface IEntity<E> : IEntity, IModel<E>
        where E : IEntity<E>, new()
    {

    }
}