//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdSvc commands(IWfRuntime wf)
            => AppCmd.create(wf, new ICmdProvider[]{
                wf.CheckRunner()
            });

        public static void Main(params string[] args)
            => run(commands, args);
    }
}