//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;
    using static Root;
    using static core;

    partial class XSvc
    {
        [Op]
        public static AsmVars AsmVars(this IWfRuntime wf)
            => Asm.AsmVars.create(wf);

        [Op]
        public static AsmTables AsmTables(this IWfRuntime wf)
            => Asm.AsmTables.create(wf);

        [Op]
        public static AsmTokens AsmTokens(this IServiceContext context)
            => Asm.AsmTokens.create(context);

        [Op]
        public static AsmSymbols AsmSymbols(this IServiceContext context)
            => Asm.AsmSymbols.create();

        [Op]
        public static AsmRegSets AsmRegSets(this IWfRuntime context)
            => Asm.AsmRegSets.create(context);
    }
}