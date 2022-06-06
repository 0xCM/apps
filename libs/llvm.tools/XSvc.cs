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
            public LlvmConfigSvc LlvmConfig(IWfRuntime wf)
                => Service<LlvmConfigSvc>(wf);

        }

        static Svc Services = Svc.Instance;


        public static LlvmObjDumpSvc LlvmObjDump(this IWfRuntime wf)
            => llvm.LlvmObjDumpSvc.create(wf);

        public static LlvmNmSvc LlvmNm(this IWfRuntime wf)
            => llvm.LlvmNmSvc.create(wf);

        public static LlvmConfigSvc LlvmConfig(this IWfRuntime wf)
            => Services.LlvmConfig(wf);

        public static LlvmReadObjSvc LlvmReadObj(this IWfRuntime wf)
            => llvm.LlvmReadObjSvc.create(wf);

        public static LlvmMcSvc LlvmMc(this IWfRuntime wf)
            => llvm.LlvmMcSvc.create(wf);

        public static LlvmLlcSvc LlvmLLc(this IWfRuntime wf)
            => llvm.LlvmLlcSvc.create(wf);

        public static ClangSvc Clang(this IWfRuntime wf)
            => llvm.ClangSvc.create(wf);
    }
}