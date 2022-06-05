//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdService commands(IWfRuntime wf)
        {
            return AsmCoreCmd.commands(wf, new ICmdProvider[]{
                wf.PbCmd(),
                wf.IntelIntrinsicsCmd(),
                },
                true
            );
        }

        public static void Main(params string[] args)
            => run(commands,args);
    }
}