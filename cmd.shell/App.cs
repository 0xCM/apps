//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;

    [Free]
    sealed class AppCmdShell : AppCmdShell<AppCmdShell>
    {
        public static GlobalCmd commands(IWfRuntime wf)
        {
            var svc = new GlobalCmd();
            var providers = array<ICmdProvider>(
                svc,
                ProjectCmd.inject(svc, ProjectCmd.create(wf)),
                LlvmCmdProvider.create(wf, LlvmCmd.create(wf)),
                AsmCoreCmd.commands(wf),
                PolyBits.commands(wf),
                wf.XedTool(),
                wf.DiagnosticCmd(),
                wf.Machines(),
                ApiCmd.create(wf),
                CheckCmd.commands(wf),
                GenCmd.create(wf),
                AsmCmdProvider.create(wf)
                );

            return GlobalCmd.init(wf, svc, providers);
        }

        public static void Main(params string[] args)
            => run(commands, args);
    }
}