//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.DbShell)]
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.SqlDbCmd(),
                wf.WsDbCmd(),
            };

        public static new AppCmd create(IWfRuntime wf)
            => create(wf, providers(wf));
    }

    [Free]
    sealed class App : AppCmdShell<App>
    {
        static IAppCmdSvc commands(IWfRuntime wf)
            => AppCmd.create(wf);

        public static void Main(params string[] args)
            => run(commands, args);
    }
}

namespace Z0.Parts
{
    public sealed class DbShell : Part<DbShell>
    {

    }
}
