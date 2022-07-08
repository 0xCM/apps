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
            public ApiHex ApiHex(IWfRuntime wf)
                => Service<ApiHex>(wf);

            public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);

            public ProcessMemory ProcessMemory(IWfRuntime wf)
                => Service<ProcessMemory>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public ModuleArchives ModuleArchives(IWfRuntime wf)
                => Service<ModuleArchives>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static ProcessMemory ProcessMemory(this IWfRuntime wf)
            => Services.ProcessMemory(wf);

        public static MemCmd MemCmd(this IWfRuntime wf)
            => GlobalServices.CmdSvc<MemCmd>(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => Services.ModuleArchives(wf);

        public static ApiHex ApiHex(this IWfRuntime wf)
            => Services.ApiHex(wf);
    }
}