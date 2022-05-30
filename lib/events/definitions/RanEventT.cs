//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RanEvent<T> : ITerminalEvent<RanEvent<T>>
    {
        public const string EventName = GlobalEvents.Ran;

        public const EventKind Kind = EventKind.Ran;

        public static EventLevel Level => FlairKind.Ran;

        public EventId EventId {get;}

        public WfStepId StepId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair {get;}

        [MethodImpl(Inline)]
        public RanEvent(WfStepId step, T data)
        {
            EventId = EventId.define(EventName, step);
            StepId = step;
            Payload = data;
            Flair = FlairKind.Ran;
        }

        [MethodImpl(Inline)]
        public string Format()
            => RP.format(EventId, Payload);
    }
}