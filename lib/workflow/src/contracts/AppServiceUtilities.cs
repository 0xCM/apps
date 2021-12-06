//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct AppServiceUtilities : IAppServiceUtilities
    {
        public static IAppServiceUtilities create(IWfRuntime wf)
            => new AppServiceUtilities(wf);

        public IWfRuntime Wf {get;}

        public AppServiceUtilities(IWfRuntime wf)
        {
            Wf = wf;
        }
    }
}