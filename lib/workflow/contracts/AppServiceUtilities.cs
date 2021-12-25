//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct AppServiceUtilities : IAppServiceUtilities
    {
        public static IAppServiceUtilities create(IWfRuntime wf, WfHost host)
            => new AppServiceUtilities(wf, host);

        public IWfRuntime Wf {get;}

        public WfHost Host {get;}

        public AppServiceUtilities(IWfRuntime wf, WfHost host)
        {
            Wf = wf;
            Host = host;
        }
    }
}