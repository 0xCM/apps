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
    public readonly struct CreatedEvent<T> : ITerminalEvent<CreatedEvent<T>>
    {
        public const string EventName = GlobalEvents.Created;

        public const EventKind Kind = EventKind.Created;

        public EventId EventId {get;}

        public EventPayload<T> Content {get;}

        public FlairKind Flair  => FlairKind.Created;

        [MethodImpl(Inline)]
        public CreatedEvent(WfStepId step, T content, PartToken ct)
        {
            EventId = (EventName, step, ct);
            Content = content;
        }

        public string Format()
            => RP.format(EventId, Content);
    }
}