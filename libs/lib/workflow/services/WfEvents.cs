//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    readonly struct WfEvents
    {
        [MethodImpl(Inline), Op]
        internal static EventSignal signal(IWfRuntime wf)
            => Events.signal(wf.EventSink, wf.Host);

        [MethodImpl(Inline), Op]
        internal static EventSignal signal(IWfRuntime wf, WfHost host)
            => Events.signal(wf.EventSink, host);
    }
}