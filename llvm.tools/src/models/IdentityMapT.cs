//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Collections.Generic;

    public sealed class IdentityMap<T>
    {
        readonly Dictionary<Identifier,T> Data;

        public IdentityMap()
        {
            Data = new();
        }

        public bool Map(Identifier key, T value)
            => Data.TryAdd(key,value);

        public bool Mapped(Identifier key, out T value)
            => Data.TryGetValue(key, out value);

        public IEnumerable<Identifier> Keys
            => Data.Keys;

        public IEnumerable<T> Values
            => Data.Values;

        public IEnumerable<KeyValuePair<Identifier,T>> Points
            => Data;
    }
}