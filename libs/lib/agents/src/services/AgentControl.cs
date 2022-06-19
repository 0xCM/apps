//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class AgentControl : AgentControl<IAgentControl,IAgentContext>, IAgentControl
    {
        public AgentControl(IAgentContext context)
            : base(context)
        {

        }

        public AgentControl()
        {

        }

        void UpdateContext(IAgentContext context)
        {
            Context = context;
            SummaryStats = new AgentStats(context.Members.Count());
        }

        protected override async Task Configure(IAgentContext context)
            => await Task.Factory.StartNew(() => UpdateContext(context));

        Task IAgentControl.Configure(IAgentContext context)
            => Configure(context);
    }
}