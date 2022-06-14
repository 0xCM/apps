//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public DumpArchive DumpArchive(IWfRuntime wf)
                => Service<DumpArchive>(wf);

            public ModuleArchives ModuleArchives(IWfRuntime wf)
                => Service<ModuleArchives>(wf);
        }

        static Svc AppServices => Svc.Instance;

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => AppServices.ModuleArchives(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => AppServices.DumpArchive(wf);
   }
}