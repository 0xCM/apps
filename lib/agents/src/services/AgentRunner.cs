//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AgentRunner
    {
        public static void run(EventSignal signal, params string[] args)
        {
            var runner = new AgentRunner(signal, new AgentContext(SystemEventWriter.Log), args);
            runner.Exec();
        }

        AgentContext AgentContext;

        EventSignal Signal;

        AgentComplex Complex;

        IAgentControl Control;

        AgentRunner(EventSignal signal, AgentContext context, string[] args)
        {
            Signal = signal;
            AgentContext = context;
            Control = Agents.control(context);
        }

        void Exec()
        {
            Signal.Status("Starting server complex");
            Agents.complex(AgentContext).ContinueWith(complex =>
                {
                    Complex = complex.Result;
                    Signal.Status("Server complex started");
                });

            Control.Configure(AgentContext).ContinueWith(_ =>
            {
                Signal.Status($"There are {Control.SummaryStats.AgentCount.ToString()} agents in play");
            });

            term.readKey("Press any key to terminate the application");
            Terminate();
        }

        void Terminate()
        {
            if(Complex != null)
            {
                Signal.Status("Shutting down server complex");
                Complex.Stop().Wait();
                Signal.Status("Server complex shut down complete");
            }
        }


    }
}