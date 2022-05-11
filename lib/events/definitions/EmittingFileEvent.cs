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
    public readonly struct EmittingFileEvent : IInitialEvent<EmittingFileEvent>
    {
        public const string EventName = GlobalEvents.EmittingFile;

        public const EventKind Kind = EventKind.EmittingFile;

        public EventId EventId {get;}

        public FS.FilePath Target {get;}

        public FlairKind Flair => FlairKind.Running;

        [MethodImpl(Inline)]
        public EmittingFileEvent(WfStepId step, FS.FilePath target)
        {
            EventId = EventId.define(EventName, step);
            Target = target;
        }

        [MethodImpl(Inline)]
        public string Format()
            => RP.format(EventId, AppMsg.EmittingFile.Capture(Target));
    }
}