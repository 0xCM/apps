//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Z0.llvm;
    using Asm;

    public static class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {
            public ProjectDataServices ProjectData(IWfRuntime wf)
                => Service<ProjectDataServices>(wf);

            public AsmFlowCommands AsmFlows(IWfRuntime wf)
                => Service<AsmFlowCommands>(wf);

            public LlvmDataProvider LlvmDataProvider(IWfRuntime wf)
                => Service<LlvmDataProvider>(wf);

            public AsmCmdProvider AsmCmd(IWfRuntime wf)
                => Service<AsmCmdProvider>(wf);

        }

        static Svc Services = Svc.Instance;

        public static XedRuntime Inject(this XedRuntime xed)
            => Services.Inject(xed);

        public static ProjectDataServices ProjectData(this IWfRuntime wf)
            => Services.ProjectData(wf);

        public static XedDisasmSvc XedDisasmSvc(this IWfRuntime wf)
            => Services.Injected<XedRuntime>().Disasm;

        public static AsmFlowCommands AsmFlows(this IWfRuntime wf)
            => Services.AsmFlows(wf);

        public static LlvmDataProvider LlvmDataProvider(this IWfRuntime wf)
            => Services.LlvmDataProvider(wf);

        public static AsmCmdProvider AsmCmd(this IWfRuntime wf)
            => Services.AsmCmd(wf);

        public static LlvmDataCalcs LlvmDataCalcs(this IWfRuntime wf)
            => llvm.LlvmDataCalcs.create(wf);

        public static LlvmCmdProvider LlvmCommands(this IWfRuntime wf)
            => llvm.LlvmCmdProvider.create(wf);

        public static LlvmTableLoader LlvmTableLoader(this IWfRuntime wf)
            => llvm.LlvmTableLoader.create(wf);

        public static LlvmObjDumpSvc LlvmObjDump(this IWfRuntime wf)
            => llvm.LlvmObjDumpSvc.create(wf);

        public static LlvmNmSvc LlvmNm(this IWfRuntime wf)
            => llvm.LlvmNmSvc.create(wf);

        public static LlvmConfigSvc LlvmConfig(this IWfRuntime wf)
            => llvm.LlvmConfigSvc.create(wf);

        public static LlvmReadObjSvc LlvmReadObj(this IWfRuntime wf)
            => llvm.LlvmReadObjSvc.create(wf);

        [Op]
        public static LlvmRepo LlvmRepo(this IWfRuntime wf)
            => llvm.LlvmRepo.create(wf);

        [Op]
        public static LlvmMcSvc LlvmMc(this IWfRuntime wf)
            => llvm.LlvmMcSvc.create(wf);

        [Op]
        public static LlvmDataImporter LlvmDataImporter(this IWfRuntime wf)
            => llvm.LlvmDataImporter.create(wf);

        [Op]
        public static LlvmPaths LlvmPaths(this IWfRuntime context)
            => llvm.LlvmPaths.create(context);

        [Op]
        public static LlvmToolset LLvmToolset(this IWfRuntime wf)
            => llvm.LlvmToolset.create(wf);

        [Op]
        public static LlvmCodeGen LlvmCodeGen(this IWfRuntime wf)
            => llvm.LlvmCodeGen.create(wf);

        [Op]
        public static LlvmLlcSvc LlvmLLc(this IWfRuntime wf)
            => llvm.LlvmLlcSvc.create(wf);


        [Op]
        public static LlvmDataEmitter LlvmDataEmitter(this IWfRuntime wf)
            => llvm.LlvmDataEmitter.create(wf);

        [Op]
        public static LlvmData LlvmData(this IWfRuntime wf)
            => llvm.LlvmData.create(wf);

        [Op]
        public static ClangSvc Clang(this IWfRuntime wf)
            => llvm.ClangSvc.create(wf);
    }
}