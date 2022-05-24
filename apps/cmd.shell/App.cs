//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;

    [Free]
    sealed class AppCmdShell : WfApp<AppCmdShell>
    {
        IAppCmdService CmdService;

        public static GlobalCmd commands(IWfRuntime wf)
        {
            var svc = new GlobalCmd();
            var asmrt = wf.AsmCmdRt(false);
            var providers = array<ICmdProvider>(
                svc,
                ProjectCmd.inject(svc, asmrt, ProjectCmd.create(wf)),
                LlvmCmdProvider.create(wf, LlvmCmd.create(wf)),
                asmrt.Commands,
                //PbCmd.create(wf),
                ApiCmd.create(wf),
                CheckCmd.create(wf),
                GenCmd.create(wf),
                AsmCmdProvider.create(wf)
                );

            return GlobalCmd.init(wf, svc, asmrt, providers);
        }

        protected override void Initialized()
        {
            CmdService = commands(Wf);
        }

        protected override void Disposing()
        {
            CmdService?.Dispose();
        }

        protected override void Run()
            => CmdService.Run();

        public static void Main(params string[] args)
        {
            using var wf = WfAppLoader.load();
            using var shell = commands(wf);
            shell.Run();
        }
    }
}