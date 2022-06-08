//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppCmdShell<S> : AppShell<S>
        where S : AppCmdShell<S>, new()
    {
        IAppCmdService CmdService;

        protected static void run(Func<IWfRuntime,IAppCmdService> f, params string[] args)
        {
            using var app = shell(args);
            app.CmdService = f(app.Wf);
            app.Run();
        }

        protected override void Disposing()
        {
            CmdService?.Dispose();
        }

        protected override void Run()
            => CmdService.Run();
    }
}