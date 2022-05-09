//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct WfEmitters : IWfEmitters
    {
        public IWfRuntime Wf {get;}

        public EnvData Env {get;}

        public WfEmitters(IWfRuntime wf, EnvData env)
        {
            Wf = wf;
            Env = env;
        }


        public void Dispose()
        {

        }
    }
}