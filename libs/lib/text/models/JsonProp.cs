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
        public NameOld Name {get;}

        public JsonText Value {get;}

        [MethodImpl(Inline)]
        public JsonProp(NameOld name, JsonText value)
        {
            Name = name;
            Value = value;
        }

        public KeyedValue<NameOld,string> Unescape()
            => (Name, Value.Unescape());
    }
}