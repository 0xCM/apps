//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        public static CgSvc CodeGen(this IWfRuntime wf)
            => Z0.CgSvc.create(wf);

        [Op]
        public static Asm.AsmModelGen AsmModelGen(this IWfRuntime wf)
            => Asm.AsmModelGen.create(wf);
    }
}