//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public static class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {
            public AssetServices Assets(IWfRuntime wf)
                => Service<AssetServices>(wf);
        }

        static Svc Services => Svc.Instance;


        public static AssetServices Assets(this IWfRuntime wf)
            => Services.Assets(wf);

    }
}