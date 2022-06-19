//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct RanCmdEvent : ITerminalEvent<RanCmdEvent>
    {
        public const string EventName = GlobalEvents.RanCmd;

        public const EventKind Kind = EventKind.CmdRan;

        public EventId EventId {get;}

        public CmdResult Result {get;}
        public FlairKind Flair => FlairKind.Ran;

        [MethodImpl(Inline)]
        public RanCmdEvent(CmdResult cmd, PartToken ct = default)
        {
            EventId = (EventName, cmd.CmdId, ct);
            Result = default;
        }

        [MethodImpl(Inline)]
        public string Format()
            => EventId.Format();
    }
}