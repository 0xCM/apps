//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    partial class TestApp<A>
    {
        Duration ExecExplicit(IExplicitTest unit, string hostpath, List<TestCaseRecord> results)
        {
            var clock = Time.counter(false);
            var messages = sys.empty<IAppMsg>();
            var casename = TestCaseName(unit);

            try
            {
                clock.Start();
                unit.Execute();
                clock.Stop();

                messages = CollectMessages(unit, casename,clock);
                results.AddRange(CollectResults(unit, casename, clock));

            }
            catch(Exception e)
            {
                clock.Stop();
                messages = CollectMessages(unit, casename, clock, e);
                results.AddRange(CollectResults(unit,casename, clock,e));
            }
            finally
            {
                term.print(messages);
            }
            return clock;
        }
    }
}