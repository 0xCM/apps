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
    public readonly struct ProcessedFileEvent<T,M> : ITerminalEvent<ProcessedFileEvent<T,M>>
    {
        public const EventKind Kind = EventKind.ProcessedFile;

        public const string EventName = GlobalEvents.ProcessedFile;

        public EventId EventId {get;}

        public T FileKind {get;}

        public M Metric {get;}

        public FS.FilePath SourcePath {get;}

        public FlairKind Flair => FlairKind.Processed;

        [MethodImpl(Inline)]
        public ProcessedFileEvent(WfStepId step, FS.FilePath src, T kind,  M metric, CorrelationToken ct)
        {
            EventId = (Kind, step, ct);
            SourcePath = src;
            FileKind = kind;
            Metric = metric;
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.format(RP.PSx4, EventId, FileKind, Metric, SourcePath.ToUri());
    }
}