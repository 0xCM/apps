//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    sealed class App : WfApp<App>
    {
        CheckRunCmd Commands;

        protected override void Initialized()
        {
            Commands = CheckRunCmd.create(Wf);
        }

        protected override void Disposing()
        {
            Commands.Dispose();
        }

        protected override void Run()
            => Commands.Run();

        public static void Main(params string[] args)
        {
            var parts = array(PartId.TestUnits, PartId.Lib);
            using var wf = ApiRuntime.create(parts, args, "test.runner.commands");
            using var shell = create(wf);
            shell.Run();
        }
    }
}