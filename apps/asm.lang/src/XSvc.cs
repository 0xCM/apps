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
        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Svc.NasmCatalog.create(wf);


        [Op]
        public static Svc.AsmModelGen AsmModelGen(this IWfRuntime wf)
            => Svc.AsmModelGen.create(wf);
    }
}