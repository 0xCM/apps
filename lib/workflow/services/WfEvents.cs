//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    readonly struct WfEvents
    {
        const string HandlerNotFound = "Handler for {0} not found";

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        internal static EventSignal signal(IWfRuntime wf)
            => EventSignals.signal(wf.EventSink, wf.Host);

        [MethodImpl(Inline), Op]
        internal static EventSignal signal(IWfRuntime wf, WfHost host)
            => EventSignals.signal(wf.EventSink, host);
    }
}