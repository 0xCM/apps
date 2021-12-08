//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    sealed partial class AppCommands : AppCmdService<AppCommands,CmdShellState>
    {
        protected override void Initialized()
        {
            State.Init(Wf, Ws);
            RunTests();
        }


        void RunTests()
        {
            var checkers = Checkers.services(Wf, Parts.TestUnits.Assembly);
            Status(string.Format("Found {0} checkers", checkers.Length));
            iter(checkers, svc => svc.Run());
            //TestRunner.Run(core.array(PartId.Lib,PartId.TestUnits));
        }
    }

    [Free]
    sealed class App : WfApp<App>
    {
        AppCommands Commands;

        protected override void Initialized()
        {
            Commands = AppCommands.create(Wf);
        }

        protected override void Disposing()
        {
            Commands.Dispose();
        }

        protected override void Run()
            => Commands.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load("test.runner.commands");
            using var shell = create(wf);
            shell.Run();
        }
    }
}