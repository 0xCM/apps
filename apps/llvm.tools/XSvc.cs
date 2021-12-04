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
        public static LlvmObjDump LlvmObjDump(this IWfRuntime wf)
            => llvm.LlvmObjDump.create(wf);

        [Op]
        public static LlvmNm LlvmNm(this IWfRuntime wf)
            => llvm.LlvmNm.create(wf);

        [Op]
        public static LlvmReadObj LlvmReadObj(this IWfRuntime wf)
            => llvm.LlvmReadObj.create(wf);

        [Op]
        public static LlvmRepo LlvmRepo(this IWfRuntime wf)
            => llvm.LlvmRepo.create(wf);

        [Op]
        public static LlvmMc LlvmMc(this IWfRuntime wf)
            => llvm.LlvmMc.create(wf);

        [Op]
        public static LlvmEtl LlvmRecordEtl(this IWfRuntime wf)
            => llvm.LlvmEtl.create(wf);

        [Op]
        public static LlvmProjectCollector LlvmProjectCollector(this IWfRuntime wf)
            => llvm.LlvmProjectCollector.create(wf);

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
        public static LlvmLlc LlvmLLc(this IWfRuntime wf)
            => llvm.LlvmLlc.create(wf);

        [Op]
        public static LlvmDataProvider LlvmDataProvider(this IWfRuntime wf)
            => llvm.LlvmDataProvider.create(wf);

        [Op]
        public static LlvmDataEmitter LlvmDataEmitter(this IWfRuntime wf)
            => llvm.LlvmDataEmitter.create(wf);

    }
}