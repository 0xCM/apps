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

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public MsilPipe MsilSvc(IWfRuntime wf)
                => Service<MsilPipe>(wf);

            public ApiJit Jit(IWfRuntime wf)
                => Service<ApiJit>(wf);

            public DumpArchive DumpArchive(IWfRuntime wf)

                => Service<DumpArchive>(wf);

            public ModuleArchives ModuleArchives(IWfRuntime wf)
                => Service<ModuleArchives>(wf);

        }

        static Svc Services => Svc.Instance;

        public static ApiMd ApiMetadata(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

         public static MsilPipe MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static ApiJit Jit(this IWfRuntime wf)
            => Services.Jit(wf);

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => Services.ModuleArchives(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);

    }

        // sealed class AppSvcCache : AppServices<AppSvcCache>
        // {


        // }


        // static AppSvcCache Services => AppSvcCache.Instance;



}