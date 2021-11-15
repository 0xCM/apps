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

    public struct JsonSetting : ISetting
    {
        public string Name {get;}

        public dynamic Value {get;}

        [MethodImpl(Inline)]
        public JsonSetting(string name, dynamic value)
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