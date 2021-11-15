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
    public readonly struct CreatingEvent : IInitialEvent<CreatingEvent>
    {
        public const string EventName = GlobalEvents.Creating;

        public const EventKind Kind = EventKind.Creating;

        public EventId EventId {get;}

        public FlairKind Flair => FlairKind.Creating;

        [MethodImpl(Inline)]
        public CreatingEvent(WfStepId step, CorrelationToken ct)
        {
            EventId = (EventName, step, ct);
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();
    }
}