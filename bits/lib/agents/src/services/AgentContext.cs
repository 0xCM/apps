//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a shared context for a set of agents
    /// </summary>
    public class AgentContext : IAgentContext
    {
        public IAgentEventSink EventLog {get;}

        ConcurrentDictionary<ulong,IAgent> Agents {get;}
            = new ConcurrentDictionary<ulong, IAgent>();

        [MethodImpl(Inline)]
        public AgentContext(IAgentEventSink sink)
        {
            EventLog = sink;
        }

        public void Register(IAgent agent)
            => Agents.TryAdd(agent.Identity, agent);

        public IEnumerable<IAgent> Members
            => Agents.Values;
    }
}