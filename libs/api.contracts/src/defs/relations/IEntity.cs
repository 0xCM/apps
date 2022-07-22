//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEntity : IElement
    {
        uint Key {get;}
    }

    [Free]
    public interface IEntity<T> : IEntity, IElement<T>
        where T : IEntity<T>
    {

    }

    [Free]
    public interface IEntity<K,V> : IValue<V>
    {
        K Key {get;}
    }
}