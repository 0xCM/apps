//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class AppShellCmd : AppCmdService<AppShellCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.ToolCmd(),                
                };

        public static AppShellCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}