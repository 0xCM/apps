//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = JsonData;

    public struct JsonSetting<T> : ISetting<T>
    {
        public string Name {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public JsonSetting(string name, T value)
        {
            Name = name;
            Value = value;
        }
        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();
    }
}