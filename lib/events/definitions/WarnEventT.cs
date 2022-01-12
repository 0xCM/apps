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
    public readonly struct WarnEvent<T> : ILevelEvent<WarnEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Warning;

        public LogLevel EventLevel => LogLevel.Warning;

        public const EventKind Kind = EventKind.Warn;

        public EventId EventId {get;}

        public WfStepId StepId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Warning;

        [MethodImpl(Inline)]
        public WarnEvent(WfStepId step, T content)
        {
            EventId = EventId.define(EventName, step);
            Payload = content;
            StepId = step;
        }

        public string Format()
            => text.format(EventId, StepId, Payload);
    }
}