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
    public readonly struct ProcessingFileEvent<T> : IInitialEvent<ProcessingFileEvent<T>>
    {
        public const string EventName = GlobalEvents.ProcessingFile;

        public const EventKind Kind = EventKind.ProcessingFile;

        public EventId EventId {get;}

        public T FileKind {get;}

        public FS.FilePath SourcePath {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public ProcessingFileEvent(WfStepId step, T kind, FS.FilePath src, CorrelationToken ct)
        {
            EventId = EventId.define(EventName, step);
            SourcePath = src;
            FileKind = kind;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format(EventId, SourcePath.ToUri());
    }
}