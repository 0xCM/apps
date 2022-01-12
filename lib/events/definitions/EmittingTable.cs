//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System;

    using static Root;

    [Event(Kind)]
    public readonly struct EmittingTableEvent : IInitialEvent<EmittingTableEvent>
    {
        public const string EventName = GlobalEvents.EmittingTable;

        public const EventKind Kind = EventKind.EmittingTable;

        public EventId EventId {get;}

        public TableId TableId {get;}

        public FS.FilePath Target {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public EmittingTableEvent(WfStepId step, Type type, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            TableId = Z0.TableId.identify(type);
            Target = target;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format(EventId, Msg.EmittingTable.Capture(TableId, Target));


        public override string ToString()
            => Format();
    }
}