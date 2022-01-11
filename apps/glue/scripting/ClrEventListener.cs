//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;

    using Level = System.Diagnostics.Tracing.EventLevel;

    using static core;

    public class ClrEventListener : EventListener
    {
        public static ClrEventListener create(Receiver<EventWrittenEventArgs> receiver)
            => new ClrEventListener(receiver);

        HashSet<string> EventNames;

        Receiver<EventWrittenEventArgs> Receiver;

        public ClrEventListener(Receiver<EventWrittenEventArgs> receiver)
            : this(receiver,"MethodLoad_V1","MethodLoadVerbose_V1","MethodJitInliningSucceeded", "MethodJitInliningFailed")
        {
        }

        public ClrEventListener(Receiver<EventWrittenEventArgs> receiver, params string[] events)
        {
            Receiver = receiver;
            EventNames = hashset(events);
        }

        protected override void OnEventSourceCreated(EventSource src)
        {
            EventKeywords keywords = (EventKeywords)(0x1010);
            EnableEvents(src, Level.Verbose, keywords);
        }

        protected override void OnEventWritten(EventWrittenEventArgs data)
        {
            if (!EventNames.Contains(data.EventName))
                return;

            Receiver(data);
        }
    }
}