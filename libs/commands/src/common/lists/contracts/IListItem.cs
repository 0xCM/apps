//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IListItem
    {
        uint Key {get;}

        object Value {get;}
    }

    public interface IListItem<T> : IListItem
    {
        new T Value {get;}

        object IListItem.Value
            => Value;
    }

    public interface IListItem<K,T> : IListItem<T>
    {
        new K Key {get;}

        uint IListItem.Key
            => core.hash(Key);
    }
}