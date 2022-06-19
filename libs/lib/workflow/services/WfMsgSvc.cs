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

        public Type HostType {get;}

        public WfMsgSvc(IWfRuntime wf, Type host, EnvData env)
        {
            Wf = wf;
            HostType = host;
            Env = env;
        }


        public void Dispose()
        {

        }
    }
}