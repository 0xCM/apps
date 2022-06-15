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

           public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);

            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

        }

        static Svc Services => Svc.Instance;

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => Services.ModuleArchives(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);

        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Services.MemoryEmitter(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);
   }
}