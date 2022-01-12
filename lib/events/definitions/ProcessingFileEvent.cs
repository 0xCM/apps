//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Event(Kind)]
    public readonly struct ProcessingFileEvent : IInitialEvent<ProcessingFileEvent>
    {
        public const string EventName = GlobalEvents.ProcessingFile;

        public const EventKind Kind = EventKind.ProcessingFile;

        public EventId EventId {get;}

        public FS.FilePath SourcePath {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public ProcessingFileEvent(WfStepId step, FS.FilePath src, CorrelationToken ct)
        {
            EventId = EventId.define(EventName, step);
            SourcePath = src;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format(RP.PSx2, EventId, SourcePath.ToUri());
    }
}