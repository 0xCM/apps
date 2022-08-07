//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IKeyed
    {
        dynamic Key {get;}
    }

    [Free]
    public interface IKeyed<K> : IKeyed
        where K : IEquatable<K>, IComparable<K>
    {
        new K Key {get;}

        dynamic IKeyed.Key
            => Key;
    }
}