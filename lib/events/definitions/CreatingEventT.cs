//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct CreatingEvent<T> : IInitialEvent<CreatingEvent<T>>
    {
        public const string EventName = GlobalEvents.Creating;

        public const EventKind Kind = EventKind.Creating;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Creating;

        [MethodImpl(Inline)]
        public CreatingEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Payload = msg;
        }

        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);

        public override string ToString()
            => Format();

    }
}