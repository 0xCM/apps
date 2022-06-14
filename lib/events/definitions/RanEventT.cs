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

        public FlairKind Flair => FlairKind.Ran;

        public EventId EventId {get;}

        public Type Host {get;}

        [MethodImpl(Inline)]
        public RanEvent(Type host, T msg)
        {
            EventId = EventId.define(host, Kind);
            Host = host;
        }

        [MethodImpl(Inline)]
        public RanEvent(RunningEvent<T> e)
        {
            EventId = e.EventId;
            Host = e.Host;
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();


        public override string ToString()
            => Format();
    }
}