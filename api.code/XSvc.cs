//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    partial class XTend
    {
    }

    public static class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {
            public ApiCode ApiCode(IWfRuntime wf)
                => Service<ApiCode>(wf);

            public ApiCodeFiles ApiCodeFiles(IWfRuntime wf)
                => Service<ApiCodeFiles>(wf);


            public ApiHexPacks HexPack(IWfRuntime wf)
                => Service<ApiHexPacks>(wf);

        }

        static Svc Services => Svc.Instance;

        public static ApiCode ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiCodeFiles ApiCodeFiles(this IWfRuntime wf)
            => Services.ApiCodeFiles(wf);

        public static ApiHexPacks HexPack(this IWfRuntime wf)
            => Services.HexPack(wf);
    }
}