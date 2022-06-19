//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct JsonProp
    {
        public Name Name {get;}

        public JsonText Value {get;}

        [MethodImpl(Inline)]
        public JsonProp(Name name, JsonText value)
        {
            Name = name;
            Value = value;
        }

        public KeyedValue<Name,string> Unescape()
            => (Name, Value.Unescape());
    }
}