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
    public readonly struct RunningEvent : IInitialEvent<RunningEvent>
    {
        public const string EventName = GlobalEvents.Running;

        public const EventKind Kind = EventKind.Running;

        public static EventLevel Level => FlairKind.Status;

        public FlairKind Flair => FlairKind.Running;

        public EventId EventId {get;}

        [MethodImpl(Inline)]
        public RunningEvent(WfStepId step, CorrelationToken ct)
        {
            EventId = EventId.define(EventName, step);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();
    }
}