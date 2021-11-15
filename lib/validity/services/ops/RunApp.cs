//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class TestApp<A>
    {
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

        public static void Run(Index<PartId> parts, Action<IWfRuntime> runner)
        {
            using var shell = WfAppLoader.load(parts, array<string>());
            runner(shell);
        }
    }
}