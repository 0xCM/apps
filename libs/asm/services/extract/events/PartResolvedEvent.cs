//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class PartResolvedEvent : ApiExtractEvent<PartResolvedEvent,ResolvedPart>
    {
        [MethodImpl(Inline)]
        public PartResolvedEvent()
        {
            Payload = ResolvedPart.Empty;
        }

        [MethodImpl(Inline)]
        public PartResolvedEvent(in ResolvedPart src)
        {
            Payload = src;
        }
    }
}