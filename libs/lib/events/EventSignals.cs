//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct EventSignals
    {
        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, WfHost host)
            => new EventSignal(sink, host);

        [MethodImpl(Inline), Op]
        public static EventSignal signal(IEventSink sink, Type host)
            => new EventSignal(sink, host);
    }
}