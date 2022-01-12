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
    public readonly struct CreatedEvent : ITerminalEvent<CreatedEvent>
    {
        public const string EventName = GlobalEvents.Created;

        public const EventKind Kind = EventKind.Created;

        public EventId EventId {get;}

        public FlairKind Flair => FlairKind.Created;

        [MethodImpl(Inline)]
        public CreatedEvent(WfStepId step, CorrelationToken ct)
        {
            EventId = (EventName, step, ct);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();
    }
}