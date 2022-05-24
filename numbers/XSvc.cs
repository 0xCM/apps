//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ServiceCache : ServiceCache<ServiceCache>
    {


    }

    public static class XSvc
    {
        static ServiceCache Services = new();

        public static Parsers Parsers(this IWfRuntime wf)
            => Services.Service<Parsers>(wf);

        [Op]
        public static WsProjects WsProjects(this IWfRuntime wf)
            => Services.Service<WsProjects>(wf);

        [Op]
        public static AppDb AppDb(this IWfRuntime wf)
            => Services.Service<AppDb>(wf);

        [Op]
        public static DumpArchives DumpArchives(this IWfRuntime wf)
            => Services.Service<DumpArchives>(wf);

        [Op]
        public static AppServices AppServices(this IWfRuntime wf)
            => Services.Service<AppServices>(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Z0.CheckRunner.create(wf);
    }
}