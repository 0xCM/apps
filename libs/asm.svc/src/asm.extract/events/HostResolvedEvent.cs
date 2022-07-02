//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class HostResolvedEvent : ApiExtractEvent<HostResolvedEvent,ResolvedHost>
    {
        [MethodImpl(Inline)]
        public HostResolvedEvent()
        {
            Payload = ResolvedHost.Empty;
        }

        [MethodImpl(Inline)]
        public HostResolvedEvent(in ResolvedHost src)
        {
            Payload = src;
        }
    }
}