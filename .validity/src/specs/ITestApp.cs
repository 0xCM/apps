//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;

    public interface ITestApp
    {
        void EmitLogs();

        Duration RunCase(IUnitTest unit, MethodInfo method, List<TestCaseRecord> cases);

        TestCaseRecord[] SortResults();

        BenchmarkRecord[] SortBenchmarks();

        void RunUnit(Type host, IUnitTest unit);
    }
}