//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SourcedEvents;

    public abstract class TraceEventAdapter<A>
        where A : TraceEventAdapter<A>, new()
    {
        public TraceEvent Subject {get; set;}

        public AgentEventId EventIdentity
            => api.identify(Subject);

        public T Field<T>(string Name)
            => api.payload<T>(Subject, Name);
    }
}