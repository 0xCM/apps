// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittedFileEvent : ITerminalEvent<EmittedFileEvent>
    {
        public const string EventName = GlobalEvents.EmittedFile;

        public const EventKind Kind = EventKind.EmittedFile;

        public EventId EventId {get;}

        public FS.FilePath Path {get;}

        public Count LineCount {get;}

        public FlairKind Flair => FlairKind.Ran;

        [MethodImpl(Inline)]
        public EmittedFileEvent(Type host, FS.FilePath dst, Count count = default)
        {
            EventId = EventId.define(host, Kind);
            LineCount = count;
            Path = dst;
        }

        public string Format()
            => LineCount != 0
            ? RP.format(EventId, AppMsg.EmittedFileLines.Capture(LineCount,Path))
            : RP.format(EventId, AppMsg.EmittedFile.Capture(Path));

        public override string ToString()
            => Format();
    }
}