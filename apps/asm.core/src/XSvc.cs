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
        public static AsmRegSets AsmRegSets(this IServiceContext context)
            => Svc.AsmRegSets.create(context);

        [Op]
        public static AsmSymbols AsmSymbols(this IServiceContext context)
            => Svc.AsmSymbols.create();

        [Op]
        public static AsmTokens AsmTokens(this IServiceContext context)
            => Svc.AsmTokens.create(context);
    }
}