//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct WfMsgSvc : IWfMsg
    {
        public IWfRuntime Wf {get;}

        public EnvData Env {get;}

        public WfMsgSvc(IWfRuntime wf, EnvData env)
        {
            Wf = wf;
            Env = env;
        }


        public void Dispose()
        {

        }
    }
}