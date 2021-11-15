//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.LlvmTools)]

namespace Z0.Parts
{
    public sealed class Llvm : Part<Llvm>
    {

    }
}

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
        public static LlvmRepo LlvmRepo(this IWfRuntime wf)
            => llvm.LlvmRepo.create(wf);

        [Op]
        public static McSyntaxLogs McSyntaxLogs(this IWfRuntime wf)
            => llvm.McSyntaxLogs.create(wf);

        [Op]
        public static LlvmRecordEtl LlvmRecordEtl(this IWfRuntime wf)
            => llvm.LlvmRecordEtl.create(wf);

        [Op]
        public static LlvmProjectEtl LlvmProjectEtl(this IWfRuntime wf)
            => llvm.LlvmProjectEtl.create(wf);

        [Op]
        public static LlvmPaths LlvmPaths(this IServiceContext context)
            => llvm.LlvmPaths.create(context);

        [Op]
        public static LlvmDb LlvmDb(this IWfRuntime wf)
            => llvm.LlvmDb.create(wf);

        [Op]
        public static ILlvmWorkspace LlvmWs(this IEnvProvider env)
            => Z0.LlvmWs.create(env.Env.LlvmRoot);

        [Op]
        public static LlvmToolbase LLvmToolbase(this IWfRuntime wf)
            => llvm.LlvmToolbase.create(wf);

        [Op]
        public static LlvmCodeGen LlvmEtlCodeGen(this IWfRuntime wf)
            => llvm.LlvmCodeGen.create(wf);
    }
}