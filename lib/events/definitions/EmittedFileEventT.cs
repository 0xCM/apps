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
    public readonly struct EmittedFileEvent<T> : ITerminalEvent<EmittedFileEvent<T>>
    {
        public const string EventName = GlobalEvents.EmittedFile;

        public const EventKind Kind = EventKind.EmittedFile;

        public EventId EventId {get;}

        public EventPayload<T> Payload {get;}

        public FS.FilePath Target {get;}

        public Count SegmentCount {get;}

        public FlairKind Flair => FlairKind.Ran;

        [MethodImpl(Inline)]
        public EmittedFileEvent(WfStepId step, T payload, Count segments, FS.FilePath target, PartToken ct)
        {
            EventId = EventId.define(EventName, step);
            SegmentCount = segments;
            Payload = payload;
            Target = target;
        }

        [MethodImpl(Inline)]
        public EmittedFileEvent(WfStepId step, T payload, FS.FilePath target, PartToken ct)
        {
            EventId = EventId.define(EventName, step);
            SegmentCount = 0;
            Payload = payload;
            Target = target;
        }

        [MethodImpl(Inline)]
        public string Format()
            => SegmentCount != 0
            ? RP.format(EventId, Payload, SegmentCount, AppMsg.EmittedFile.Capture(Target))
            : RP.format(EventId, Payload, AppMsg.EmittedFile.Capture(Target));
    }
}