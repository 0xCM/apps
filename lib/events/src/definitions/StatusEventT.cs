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
    public readonly struct StatusEvent<T> : ILevelEvent<StatusEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Status;

        public const EventKind Kind = EventKind.Status;

        public LogLevel EventLevel => LogLevel.Status;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Status;

        [MethodImpl(Inline)]
        public StatusEvent(WfStepId step, T data, CorrelationToken ct = default)
        {
            EventId = EventId.define(EventName, step);
            Payload = data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);
    }
}