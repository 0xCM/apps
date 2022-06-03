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
            return XedCmd.commands(wf,true);
            // return AsmCoreCmd.commands(wf, new ICmdProvider[]{
            //     wf.IntelIntrinsicsCmd(),
            //     XedCmd.commands(wf,true)
            //     },
            //     true
            // );
        }

        public static void Main(params string[] args)
            => run(commands,args);
    }
}