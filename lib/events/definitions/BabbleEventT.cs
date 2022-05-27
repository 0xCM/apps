//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct BabbleEvent<T> : ILevelEvent<BabbleEvent<T>,T>
    {
        public const string EventName = GlobalEvents.Babble;

        public const EventKind Kind = EventKind.Babble;

        public LogLevel EventLevel => LogLevel.Babble;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Babble;

        [MethodImpl(Inline)]
        public BabbleEvent(WfStepId step, T data, PartToken ct)
        {
            EventId = (EventName, step, ct);
            Payload = data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => RP.format(EventId, Payload);
    }
}