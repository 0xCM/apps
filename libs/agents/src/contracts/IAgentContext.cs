//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAgentContext
    {
        IEnumerable<IAgent> Members {get;}

        IAgentEventSink EventLog {get;}

        void Register(IAgent agent);
    }
}