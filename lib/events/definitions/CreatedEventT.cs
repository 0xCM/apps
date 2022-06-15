//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct CreatedEvent : ITerminalEvent<CreatedEvent>
    {
        public const string EventName = GlobalEvents.Created;

        public const EventKind Kind = EventKind.Created;

        public EventId EventId {get;}

        public FlairKind Flair  => FlairKind.Created;

        [MethodImpl(Inline)]
        public CreatedEvent(Type host)
        {
            EventId = EventId.define(host, Kind);
        }

        [MethodImpl(Inline)]
        public CreatedEvent(CreatingEvent prior)
        {
            EventId = prior.EventId;
        }

        public string Format()
            => EventId.Format();

        public override string ToString()
            => Format();
    }
}