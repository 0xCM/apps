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
        public EmittedFileEvent(WfStepId step, FS.FilePath path, Count count)
        {
            EventId = EventId.define(EventName, step);
            LineCount = count;
            Path = path;
        }

        [MethodImpl(Inline)]
        public EmittedFileEvent(WfStepId step, FS.FilePath path)
        {
            EventId = EventId.define(EventName, step);
            LineCount = 0;
            Path = path;
        }

        public string Format()
            => LineCount != 0
            ? text.format(EventId, AppMsg.EmittedFileLines.Capture(LineCount,Path))
            : text.format(EventId, AppMsg.EmittedFile.Capture(Path));
    }
}