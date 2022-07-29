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
            public CliEmitter CliEmitter(IWfRuntime wf)
                => Service<CliEmitter>(wf);

            public Cli Cli(IWfRuntime wf)
                => Service<Cli>(wf);

            public MsilPipe MsilSvc(IWfRuntime wf)
                => Service<MsilPipe>(wf);

            public CliCmd CliCmd(IWfRuntime wf)
                => Service<CliCmd>(wf);

            public RoslnCmd SourceSymbolic(IWfRuntime wf)
                => Service<RoslnCmd>(wf);

            public Roslyn Roslyn(IWfRuntime wf)
                => Service<Roslyn>(wf);

        }

        static Svc Services => Svc.Instance;

        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Services.CliEmitter(wf);

        public static MsilPipe MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static Cli Cli(this IWfRuntime wf)
            => Services.Cli(wf);

        public static CliCmd CliCmd(this IWfRuntime wf)
            => Services.CliCmd(wf);


        public static Roslyn Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);

        public static RoslnCmd RoslynCmd(this IWfRuntime wf)
            => Services.SourceSymbolic(wf);            
    }
}