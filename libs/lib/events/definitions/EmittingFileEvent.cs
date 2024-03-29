//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct EmittingFileEvent : IInitialEvent<EmittingFileEvent>
    {
        public const string EventName = GlobalEvents.EmittingFile;

        public const EventKind Kind = EventKind.EmittingFile;

        public EventId EventId {get;}

        public FS.FilePath Target {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public EmittingFileEvent(Type host, FS.FilePath dst)
        {
            EventId = EventId.define(host, Kind);
            Target = dst;
        }

        public string Format()
            => RpOps.format(EventId, AppMsg.EmittingFile.Capture(Target));
    }
}