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
            var xed = XedRuntime.create(wf);
            var providers = new ICmdProvider[]{
                wf.IntelIntrinsicsCmd(),
                AsmCoreCmd.commands(wf),
            };
            var cmd = XedCmd.commands(xed, providers);
            xed.Start();
            return cmd;
        }

        public static void Main(params string[] args)
            => run(commands,args);
    }
}