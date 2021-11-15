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
    public readonly struct DisposedEvent : ITerminalEvent<DisposedEvent>
    {
        public const string EventName = GlobalEvents.Disposed;

        public const EventKind Kind = EventKind.Disposed;

        public EventId EventId {get;}

        public FlairKind Flair => FlairKind.Disposed;

        [MethodImpl(Inline)]
        public DisposedEvent(WfStepId step, CorrelationToken ct)
        {
            EventId = (EventName, step, ct);
        }

        public string Format()
            => EventId.Format();
    }
}