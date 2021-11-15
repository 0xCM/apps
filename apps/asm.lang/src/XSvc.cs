//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    using Svc = Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        [Op]
        public static AsmEtl AsmEtl(this IWfRuntime context)
            => Svc.AsmEtl.create(context);

        [Op]
        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Svc.NasmCatalog.create(wf);

        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Svc.AsmTables.create(wf);

        [Op]
        public static StanfordAsmCatalog StanfordCatalog(this IWfRuntime wf)
            => Svc.StanfordAsmCatalog.create(wf);

        [Op]
        public static AsmFormPipe AsmFormPipe(this IWfRuntime wf)
            => Svc.AsmFormPipe.create(wf);

        [Op]
        public static Svc.AsmModelGen AsmModelGen(this IWfRuntime wf)
            => Svc.AsmModelGen.create(wf);
    }
}