//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    partial class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.EnvCmd(),
                wf.ToolsetCmd(),
                wf.ApiSpecs()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}