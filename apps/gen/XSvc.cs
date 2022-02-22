//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static class XSvc
    {
        public static CgSvc CodeGen(this IWfRuntime wf)
            => Z0.CgSvc.create(wf);

        public static AsmCodeGen AsmCodeGen(this IWfRuntime wf)
            => Asm.AsmCodeGen.create(wf);
    }
}