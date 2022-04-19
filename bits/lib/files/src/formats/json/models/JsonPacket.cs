//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct JsonPacket
    {
        public dynamic Content {get;}

        public string Type {get;}

        [MethodImpl(Inline)]
        public JsonPacket(dynamic content, string type)
        {
            Content = content ?? RP.Null;
            Type = type ?? RP.Null;
        }
    }
}