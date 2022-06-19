//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.Diagnostics.Tracing;

    using api = SourcedEvents;

    public static class TraceEventAdapter
    {
        public static T Payload<T>(this TraceEvent e, string name)
            => (T)e.PayloadByName(name);
    }

    public abstract class TraceEventAdapter<A>
        where A : TraceEventAdapter<A>, new()
    {
        public TraceEvent Subject {get; set;}

        public AgentEventId EventIdentity
            => api.identify(Subject);

        public T Field<T>(string Name)
            => api.payload<T>(Subject, Name);
    }

    public abstract class TraceEventAdapter<A,T> : TraceEventAdapter<A>
        where A : TraceEventAdapter<A,T>, new()
        where T : unmanaged
    {
        public virtual T Body
            => core.first<T>(Subject.Payload<byte[]>(nameof(Body)).ToSpan());
    }
}