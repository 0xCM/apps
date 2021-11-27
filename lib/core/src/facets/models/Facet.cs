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

    public readonly struct Facet : IFacet<string,object>
    {
        public static Outcome parse(string src, out Facet dst)
            => api.parse(src, out dst);

        public string Key {get;}

        public dynamic Value {get;}

        [MethodImpl(Inline)]
        public Facet(string name, dynamic value)
        {
            Key = name;
            Value = value;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Facet((string name, dynamic value) src)
            => new Facet(src.name, src.value);

        public static Facet Empty => new Facet(EmptyString, EmptyString);
    }
}