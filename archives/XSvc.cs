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
            public HexCsvReader HexCsvReader(IWfRuntime wf)
                => Service<HexCsvReader>(wf);

            public HexCsvWriter HexCsvWriter(IWfRuntime wf)
                => Service<HexCsvWriter>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public WsProjects WsProjects(IWfRuntime wf)
                => Service<WsProjects>(wf);

            public WsCmdRunner WsCmdRunner(IWfRuntime wf)
                => Service<WsCmdRunner>(wf);

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public MsilPipe MsilSvc(IWfRuntime wf)
                => Service<MsilPipe>(wf);

            public ApiJit Jit(IWfRuntime wf)
                => Service<ApiJit>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

             public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);
        }

        static Svc Services => Svc.Instance;

        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Services.HexCsvReader(wf);

        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Services.HexCsvWriter(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);

        public static WsProjects WsProjects(this IWfRuntime wf)
            => Services.WsProjects(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => Services.WsCmdRunner(wf);

        public static ApiMd ApiMetadata(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static MsilPipe MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static ApiJit Jit(this IWfRuntime wf)
            => Services.Jit(wf);


        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Services.MemoryEmitter(wf);
    }
}