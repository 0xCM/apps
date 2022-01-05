//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using Z0.llvm;

    public static class XSvc
    {
        [Op]
        public static LlvmDataCalcs LlvmDataCalcs(this IWfRuntime wf)
            => llvm.LlvmDataCalcs.create(wf);

        [Op]
        public static LlvmCmdProvider LlvmCommands(this IWfRuntime wf)
            => LlvmCmdProvider.create(wf);
        [Op]
        public static LlvmTableLoader LlvmTableLoader(this IWfRuntime wf)
            => llvm.LlvmTableLoader.create(wf);

        [Op]
        public static LlvmObjDumpSvc LlvmObjDump(this IWfRuntime wf)
            => llvm.LlvmObjDumpSvc.create(wf);

        [Op]
        public static LlvmNmSvc LlvmNm(this IWfRuntime wf)
            => llvm.LlvmNmSvc.create(wf);

        [Op]
        public static LlvmConfigSvc LlvmConfig(this IWfRuntime wf)
            => llvm.LlvmConfigSvc.create(wf);

        [Op]
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
        public static ProjectCollector ProjectCollector(this IWfRuntime wf)
            => Z0.ProjectCollector.create(wf);

        [Op]
        public static LlvmPaths LlvmPaths(this IServiceContext context)
            => llvm.LlvmPaths.create(context);

        [Op]
        public static ILlvmWorkspace LlvmWs(this IEnvProvider env)
            => Z0.LlvmWs.create(env.Env.LlvmRoot);

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
        public static LlvmDataProvider LlvmDataProvider(this IWfRuntime wf)
            => llvm.LlvmDataProvider.create(wf);

        [Op]
        public static LlvmDataEmitter LlvmDataEmitter(this IWfRuntime wf)
            => llvm.LlvmDataEmitter.create(wf);

        [Op]
        public static LlvmData LlvmData(this IWfRuntime wf)
            => llvm.LlvmData.create(wf);

        [Op]
        public static CoffObjects CoffObjects(this IWfRuntime wf)
            => Z0.CoffObjects.create(wf);
    }
}