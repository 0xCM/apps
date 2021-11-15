//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class TestApp<A>
    {
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
    }
}