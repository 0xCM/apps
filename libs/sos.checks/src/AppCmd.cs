//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    class AppCmd : AppCmdService<AppCmd>
    {
        SosCmd SosCmd => Wf.SosCmd();

        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.ToolsetCmd(),
                wf.SosCmd(),
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}