//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.EnvSvc()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));

        [CmdOp("cmd/check")]
        void RunChecks()
        {

        }
    }
}