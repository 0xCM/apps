//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    struct App
    {
        public static void run(string[] args)
            => app(shell(args)).Run();

        static App app(IWfRuntime wf)
            => new App(wf);

        static IWfRuntime shell(string[] args)
            => WfAppLoader.load(args).WithSource(Rng.@default());

        IWfRuntime Wf;

        App(IWfRuntime wf)
        {
            Wf = wf;
        }

        void Run()
        {
            try
            {
                using var machine = MachineRunner.create(Wf);
                machine.Run(WorkflowOptions.@default());
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        public static void Main(params string[] args)
            => run(args);
    }

    public static partial class XTend {}
}