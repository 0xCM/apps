//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Facet : IFacet<string,object>
    {
        public string Key {get;}

        public object Value {get;}

        [MethodImpl(Inline)]
        public Facet(string name, object value)
        {
            Key = name;
            Value = value;
        }

        public string Format()
            => RP.facet(Key,Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Facet((string name, object value) src)
            => new Facet(src.name, src.value);
    }
}