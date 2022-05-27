//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RunningEvent<T> : IInitialEvent<RunningEvent<T>>
    {
        public const string EventName = GlobalEvents.Running;

        public const EventKind Kind = EventKind.Running;

        public static EventLevel Level => FlairKind.Status;

        public EventId EventId {get;}

        public WfStepId StepId {get;}

        public EventPayload<T> Payload {get;}
        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public RunningEvent(WfStepId step, T data)
        {
            EventId = EventId.define(EventName, step);
            StepId = step;
            Payload = data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, Payload);
    }
}