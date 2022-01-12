//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public class EmittedTableEvent<T> : ITerminalEvent<EmittedTableEvent<T>>
        where  T : struct
    {
        public const string EventName = GlobalEvents.EmittedTable;

        public const EventKind Kind = EventKind.EmittedTable;

        public EventId EventId {get;}

        public Count RowCount {get;}

        public FS.FilePath Target {get;}

        public TableId Table
            => TableId.identify<T>();

        public EmittedTableEvent()
        {
            EventId = EventId.Empty;
            RowCount = 0;
            Target = FS.FilePath.Empty;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(WfStepId step, Count count, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            RowCount = count;
            Target = target;
        }

        [MethodImpl(Inline)]
        public EmittedTableEvent(WfStepId step, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            RowCount = 0;
            Target = target;
        }

        public TableId TableId => TableId.identify(typeof(T));

        public FlairKind Flair => FlairKind.Ran;

        public string Format()
            => text.format(EventId, Msg.EmittedTable.Capture(TableId, RowCount, Target));


        public override string ToString()
            => Format();

        public static implicit operator EmittedTableEvent(EmittedTableEvent<T> src)
            => new EmittedTableEvent(src.EventId, src.TableId, src.RowCount, src.Target);
    }
}