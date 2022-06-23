//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Event(Kind)]
    public readonly struct ProcessingFileEvent : IInitialEvent<ProcessingFileEvent>
    {
        public const string EventName = GlobalEvents.ProcessingFile;

        public const EventKind Kind = EventKind.ProcessingFile;

        public EventId EventId {get;}

        public FS.FilePath SourcePath {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public ProcessingFileEvent(Type host, FS.FilePath src)
        {
            EventId = EventId.define(host, Kind);
            SourcePath = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, SourcePath.ToUri());
    }
}