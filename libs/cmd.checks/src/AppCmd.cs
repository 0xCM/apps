//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        // protected override void PublishCommands()
        //     => Wf.AppCmdServer().With(providers(Wf));

        static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.EnvCmd(),
                wf.DbCmd(),
                wf.ToolsetCmd(),
                wf.ScriptCmd(),
                wf.ApiSpecsCmd()
            };

        public static new AppCmd create(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}