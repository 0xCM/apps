//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public readonly struct EmittedTableEvent : ITerminalEvent<EmittedTableEvent>
    {
        public const string EventName = GlobalEvents.EmittedTable;

        public const EventKind Kind = EventKind.EmittedTable;

        public EventId EventId {get;}

        public TableId TableId {get;}

        public Count RowCount {get;}

        public FS.FilePath Target {get;}

        public FlairKind Flair => FlairKind.Ran;

        [MethodImpl(Inline)]
        internal EmittedTableEvent(EventId eid, TableId table, Count count, FS.FilePath dst)
        {
            EventId = eid;
            TableId = table;
            RowCount = count;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(WfStepId step, TableId dataset, uint count, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            TableId = dataset;
            RowCount = count;
            Target = target;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(WfStepId step, TableId dataset, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            TableId = dataset;
            RowCount = 0;
            Target = target;
        }

        public string Format()
            => text.format(EventId, Msg.EmittedTable.Capture(TableId, RowCount, Target));

        public override string ToString()
            => Format();
    }
}