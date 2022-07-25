//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.ToolsetCmd(),
                wf.ApiSpecsCmd()
            };

        public static new AppCmd create(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}