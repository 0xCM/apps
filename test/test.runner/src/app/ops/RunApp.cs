//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial class TestApp<A>
    {
        protected virtual Assembly TargetComponent {get;} = typeof(A).Assembly;

        void RunTests(bool concurrent, Index<string> hosts)
        {
            var types = hosts.IsEmpty ? FindHosts() : FindHosts(hosts);
            core.iter(types, h =>  RunUnit(h), concurrent);
        }

        protected virtual void RunTests(params string[] hosts)
        {
            try
            {
                var clock = counter(true);
                var flow = Wf.Running(typeof(A).Name + " tests");
                ErrorLogPath.Delete();
                StatusLogPath.Delete();
                RunTests(false, hosts);
                EmitLogs();
                var runtime = clock.Stop();
                Wf.Ran(flow, $"Test run required {runtime.TimeSpan.TotalSeconds} seconds");
            }
            catch (Exception e)
            {
                term.error(e);
            }
        }

        public static void Run(params string[] args)
        {
            var app = new A();
            app.InjectShell(WfAppLoader.load(args));
            app.SetMode(InDiagnosticMode);
            app.RunTests();
        }

        public static void Run(PartId part, params string[] units)
        {
            Run(array(part), units);
        }

        public static void Run(Index<PartId> parts, params string[] units)
        {
            var app = new A();
            var shell = WfAppLoader.load(parts, array<string>());
            app.InjectShell(shell);
            app.SetMode(InDiagnosticMode);
            app.RunTests(units);
        }
    }
}