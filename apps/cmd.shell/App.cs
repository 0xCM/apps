//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppShell<S> : WfApp<S>
        where S : AppShell<S>, new()
    {
        protected static S shell(params string[] args)
            => create(WfAppLoader.load());

        protected static void run(params string[] args)
        {
            using var app = shell(args);
            app.Run();
        }
    }


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

    [Free]
    sealed class AppCmdShell : AppCmdShell<AppCmdShell>
    {
        // IAppCmdService CmdService;

        // protected override void Initialized()
        // {
        //     CmdService = GlobalCmd.service(Wf);
        // }

        // protected override void Disposing()
        // {
        //     CmdService?.Dispose();
        // }

        // protected override void Run()
        //     => CmdService.Run();

        public static void Main(params string[] args)
            => run(GlobalCmd.service,args);
    }
    // [Free]
    // sealed class AppCmdShell : AppShell<AppCmdShell>
    // {
    //     IAppCmdService CmdService;

    //     protected override void Initialized()
    //     {
    //         CmdService = GlobalCmd.service(Wf);
    //     }

    //     protected override void Disposing()
    //     {
    //         CmdService?.Dispose();
    //     }

    //     protected override void Run()
    //         => CmdService.Run();

    //     public static void Main(params string[] args)
    //         => run(args);
    // }
}