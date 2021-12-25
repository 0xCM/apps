//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Gen;

    public static class XSvc
    {
        public static Generators Generators(this IWfRuntime wf)
            => Z0.Generators.create(wf);

        [Op]
        public static Asm.AsmModelGen AsmModelGen(this IWfRuntime wf)
            => Asm.AsmModelGen.create(wf);
    }
}