//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EventOrigin : ITextual
    {
        public Name OriginName {get;}

        public CallingMember Caller {get;}

        [MethodImpl(Inline)]
        public EventOrigin(string name, in CallingMember caller)
        {
            OriginName = name;
            Caller = caller;
        }

        public string Format()
            => RP.piped(OriginName, Caller);

        public override string ToString()
            => Format();
    }
}