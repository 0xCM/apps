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
                wf.ToolCmd()
                };

        public static AppShellCmd commands(IWfRuntime wf)
        {
            //var xed = ApiGlobals.Instance.Inject(wf.XedRuntime());
            return create(wf, providers(wf));
        }

        protected override void Initialized()
        {
            //RunCmd("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, "mc.models")}));
        }
    }
}