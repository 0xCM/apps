//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Faceted;

    [DataTypeAttributeD("facet<t:{0}>")]
    public readonly struct Facet<T> : IFacet<string,T>
    {
        public string Key {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public Facet(string name, T value)
        {
            Key = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(string key, T value)
        {
            key = Key;
            value = Value;
        }

        public string Format()
        {
            var k = RpOps.format("{0}", Key);
            var v = RpOps.format("{0}", Value);
            if(text.nonempty(v))
                return RpOps.facet(k, v);
            else
                return k;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Facet<T>((string name, T value) src)
            => new Facet<T>(src.name, src.value);
    }
}