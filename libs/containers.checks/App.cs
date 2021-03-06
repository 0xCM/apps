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
            => AppCmd.create(wf);

        public static void Main(params string[] args)
            => run(commands, args);
    }
}