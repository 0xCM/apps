//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using Microsoft.Diagnostics.Tracing;
    using Microsoft.Diagnostics.Tracing.Session;

    using api = SourcedEvents;

    public sealed class TraceEventSink : Agent
    {
        public static IAgent Define(AgentContext Context, AgentIdentity Identity)
            => new TraceEventSink(Context, Identity);

        TraceEventSink(AgentContext Context, AgentIdentity Identity)
            : base(Context, Identity)
        {

        }

        TraceEventSession Session;

        ConcurrentQueue<AgentEventId> TargetQueue = new ConcurrentQueue<AgentEventId>();

        void OnPulse(TraceEvent data)
        {
            var identity = api.identify(data);
            term.magenta($"Received event {identity}");

            TargetQueue.Enqueue(identity);
        }

        void OnAgentTransitioned(TraceEvent data)
        {
            var adapter = api.adapter<AgentTransitioned>(data);
            var body = adapter.Body;
            term.magenta($"Received transition event: {body}");
        }

        void OnUnhandled(TraceEvent data)
        {
            if ((int)data.ID != 0xFFFE)         // The EventSource manifest events show up as unhanded, filter them out.
                term.babble("GOT UNHANDLED EVENT: " + data.Dump());
        }

        void ConfigureSession()
        {
            Session = new TraceEventSession(nameof(TraceEventSink));
            var restarted = Session.EnableProvider(SystemEventWriter.SourceName);
            if(restarted)
                term.warn($"Session was already in progress");

            Session.Source.UnhandledEvents += OnUnhandled;
            Session.Source.Dynamic.AddCallbackForProviderEvent(SystemEventWriter.SourceName, "Pulse", OnPulse);
            Session.Source.Dynamic.AddCallbackForProviderEvent(SystemEventWriter.SourceName, "AgentTransitioned", OnAgentTransitioned);
        }

        protected override void OnStart()
        {
            ConfigureSession();
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) { OnStop(); };
        }

        protected override void OnRun()
        {
            Task.Factory.StartNew(() =>
            {
                term.babble("Processing events");
                Session.Source.Process();
                term.babble("Finished processing events");

            });
        }

        protected override void OnStop()
        {
            Dispose();
        }

        protected override void OnTerminate()
        {
            Session?.Source.Dispose();
            Session?.Dispose();
        }
    }
}