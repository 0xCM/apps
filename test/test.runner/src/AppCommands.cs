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
            CheckSvc = Checkers.services(Wf, Parts.TestUnits.Assembly).Select(x => (x.Name, x)).ToConstLookup();
        }

        public ConstLookup<Identifier,ICheckService> CheckSvc {get;private set;}

        [CmdOp("checkers/list")]
        Outcome ListCheckers(CmdArgs args)
        {
            iter(CheckSvc.Values, svc => Write(svc.Name));
            return true;
        }

        [CmdOp("checkers/run")]
        Outcome RumCheckers(CmdArgs args)
        {
            if(args.Count == 0)
                iter(CheckSvc.Values, svc => svc.Run());
            else
            {
                var count = args.Count;
                for(var i=0; i<count; i++)
                {
                    var name = args[0].Value;
                    if(CheckSvc.Find(name, out var checker))
                    {
                        checker.Run();
                    }
                    else
                    {
                        Warn(string.Format("{0} checker not found", name));
                    }
                }
            }
            return true;
        }

        [CmdOp("units/run")]
        Outcome RunUnits(CmdArgs args)
        {
            TestRunner.Run(core.array(PartId.Lib,PartId.TestUnits));
            return true;
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