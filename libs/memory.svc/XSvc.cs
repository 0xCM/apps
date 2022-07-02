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

            public HexCsv HexCsv(IWfRuntime wf)
                => Service<HexCsv>(wf);

           public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);

           public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);

            public ProcessMemory ProcessMemory(IWfRuntime wf)
                => Service<ProcessMemory>(wf);


            public ImageSegments ImageSegments(IWfRuntime wf)
                => Service<ImageSegments>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);


            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

            public DumpArchive DumpArchive(IWfRuntime wf)
                => Service<DumpArchive>(wf);

            public ModuleArchives ModuleArchives(IWfRuntime wf)
                => Service<ModuleArchives>(wf);


        }

        static Svc Services => Svc.Instance;

        public static HexCsv HexCsv(this IWfRuntime wf)
            => Services.HexCsv(wf);

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Services.MemoryEmitter(wf);

        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Services.ProcessMemory(wf);


        public static ImageSegments ImageSegments(this IWfRuntime wf)
            => Services.ImageSegments(wf);


        public static MemCmd MemCmd(this IWfRuntime wf)
            => GlobalServices.CmdSvc<MemCmd>(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => Services.ModuleArchives(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);
    }
}