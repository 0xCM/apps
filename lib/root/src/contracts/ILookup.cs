// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface ILookup
    {
        Type KeyType {get;}

        Type ValueType {get;}
    }

    [Free]
    public interface ILookup<K,V> : ILookup
    {
        bool Lookup(K key, out V value);

        Type ILookup.KeyType
            => typeof(K);

        Type ILookup.ValueType
            => typeof(V);
    }
}