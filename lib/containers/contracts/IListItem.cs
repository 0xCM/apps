//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IListItem : ITextual
    {
        uint Key {get;}

        TextBlock Value {get;}
    }

    public interface IListItem<T> : IListItem
    {

        new T Value {get;}

        TextBlock IListItem.Value
            => text.trim(Value?.ToString() ?? string.Empty);
    }

    public interface IListItem<K,T> : IListItem<T>
    {
        new K Key {get;}

        uint IListItem.Key
            => alg.hash.calc(Key.ToString());
    }
}