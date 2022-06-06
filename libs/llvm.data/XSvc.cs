//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using llvm;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public ProjectSvc ProjectSvc(IWfRuntime wf)
                => Service<ProjectSvc>(wf);

            public AsmFlowCommands AsmFlows(IWfRuntime wf)
                => Service<AsmFlowCommands>(wf);

            public LlvmDataProvider LlvmDataProvider(IWfRuntime wf)
                => Service<LlvmDataProvider>(wf);

            public AsmCmdProvider AsmCmd(IWfRuntime wf)
                => Service<AsmCmdProvider>(wf);

            public LlvmDataEmitter LlvmDataEmitter(IWfRuntime wf)
                => Service<LlvmDataEmitter>(wf);

            public LlvmToolset LLvmToolset(IWfRuntime wf)
                => Service<LlvmToolset>(wf);

            public LlvmDataCalcs LlvmDataCalcs(IWfRuntime wf)
                => Service<LlvmDataCalcs>(wf);

            public LlvmTableLoader LlvmTableLoader(IWfRuntime wf)
                => Service<LlvmTableLoader>(wf);

            public LlvmCmd LlvmCmd(IWfRuntime wf)
                => Service<LlvmCmd>(wf);

            public LlvmRepo LlvmRepo(IWfRuntime wf)
                => Service<LlvmRepo>(wf);

            public LlvmDataImporter LlvmDataImporter(IWfRuntime wf)
                => Service<LlvmDataImporter>(wf);

            public LlvmPaths LlvmPaths(IWfRuntime wf)
                => Service<LlvmPaths>(wf);

            public LlvmCodeGen LlvmCodeGen(IWfRuntime wf)
                => llvm.LlvmCodeGen.create(wf);
        }

        static Svc Services = Svc.Instance;

        public static LlvmCodeGen LlvmCodeGen(this IWfRuntime wf)
            => Services.LlvmCodeGen(wf);

        public static ProjectSvc ProjectSvc(this IWfRuntime wf)
            => Services.ProjectSvc(wf);

        public static XedDisasmSvc XedDisasmSvc(this IWfRuntime wf)
            => GlobalSvc.Instance.Service<XedRuntime>(wf).Disasm;
            //Services.Injected<XedRuntime>().Disasm;

        public static AsmFlowCommands AsmFlows(this IWfRuntime wf)
            => Services.AsmFlows(wf);

        public static LlvmDataProvider LlvmDataProvider(this IWfRuntime wf)
            => Services.LlvmDataProvider(wf);

        public static AsmCmdProvider AsmCmd(this IWfRuntime wf)
            => Services.AsmCmd(wf);

        public static LlvmDataEmitter LlvmDataEmitter(this IWfRuntime wf)
            => Services.LlvmDataEmitter(wf);

        public static LlvmToolset LLvmToolset(this IWfRuntime wf)
            => Services.LLvmToolset(wf);

        public static LlvmDataCalcs LlvmDataCalcs(this IWfRuntime wf)
            => Services.LlvmDataCalcs(wf);

        public static LlvmTableLoader LlvmTableLoader(this IWfRuntime wf)
            => Services.LlvmTableLoader(wf);

        public static LlvmCmd LlvmCmd(this IWfRuntime wf)
            => Services.LlvmCmd(wf);

        public static LlvmRepo LlvmRepo(this IWfRuntime wf)
            => Services.LlvmRepo(wf);

        public static LlvmDataImporter LlvmDataImporter(this IWfRuntime wf)
            => Services.LlvmDataImporter(wf);

        public static LlvmPaths LlvmPaths(this IWfRuntime wf)
            => Services.LlvmPaths(wf);
    }
}