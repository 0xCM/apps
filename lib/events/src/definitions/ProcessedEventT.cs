//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public class ProcessedEvent<T> : ITerminalEvent<ProcessedEvent<T>>
    {
        public const string EventName = GlobalEvents.Processed;

        public const EventKind Kind = EventKind.Processed;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public ProcessedEvent()
        {
            EventId = EventId.Empty;
            Payload = EventPayload<T>.Empty;
        }


        [MethodImpl (Inline)]
        public ProcessedEvent(WfStepId step, T payload, CorrelationToken ct = default)
        {
            EventId = EventId.define(EventName, step);
            Payload = payload;
        }

        public FlairKind Flair => FlairKind.Processed;

        [MethodImpl (Inline)]
        public string Format()
            => text.format(EventId, Payload);
    }
}