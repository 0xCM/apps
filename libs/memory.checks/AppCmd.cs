//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.MemoryChecks)]
namespace Z0
{
    using Asm;

    sealed class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.MemCmd()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }


    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdSvc commands(IWfRuntime wf)
            => AppCmd.commands(wf);

        public static void Main(params string[] args)
            => run(commands, args);
    }
}

namespace Z0.Parts
{
    public sealed class MemoryChecks : Part<MemoryChecks>
    {

    }
}
