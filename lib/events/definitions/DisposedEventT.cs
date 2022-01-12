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
    public readonly struct Disposed<T> : IWfEvent<Disposed<T>,T>
    {
        public const string EventName = GlobalEvents.Disposed;

        public const EventKind Kind = EventKind.Disposed;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FlairKind Flair => FlairKind.Disposed;

        [MethodImpl(Inline)]
        public Disposed(WfStepId step, T content, CorrelationToken ct)
        {
            EventId = (EventName, step, ct);
            Payload = content;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format(EventId, Payload);
    }
}