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
    public readonly struct RunningEvent<T> : IInitialEvent<RunningEvent<T>>
    {
        public const string EventName = GlobalEvents.Running;

        public const EventKind Kind = EventKind.Running;

        public static EventLevel Level => FlairKind.Status;

        public EventId EventId {get;}

        public WfStepId StepId {get;}

        public EventPayload<T> Payload {get;}

        public Name Operation {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public RunningEvent(WfStepId step, T data, CorrelationToken ct = default)
        {
            EventId = EventId.define(EventName, step);
            StepId = step;
            Payload = data;
            Operation = data.ToString();
        }

        [MethodImpl(Inline)]
        public RunningEvent(WfStepId step, string operation, T data, CorrelationToken ct = default)
        {
            EventId = EventId.define(EventName, step);
            Operation = operation;
            StepId = step;
            Payload = data;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Operation.IsEmpty ? text.format(EventId, Payload) : text.format(EventId, Operation, Payload);
    }
}