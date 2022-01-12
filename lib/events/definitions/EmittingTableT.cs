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
    public readonly struct EmittingTableEvent<T> : IInitialEvent<EmittingTableEvent<T>>
        where  T : struct
    {
        public const string EventName = GlobalEvents.EmittingTable;

        public const EventKind Kind = EventKind.EmittingTable;

        public EventId EventId {get;}

        public FS.FilePath Target {get;}

        public FlairKind Flair => FlairKind.Running;

        public TableId Table => TableId.identify<T>();

        [MethodImpl(Inline)]
        public EmittingTableEvent(WfStepId step, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            Target = target;
        }


        [MethodImpl(Inline)]
        public string Format()
            => text.format(EventId, Msg.EmittingTable.Capture(Table, Target));

        public override string ToString()
            => Format();
    }
}