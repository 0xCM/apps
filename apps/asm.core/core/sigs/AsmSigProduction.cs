//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class AsmSigProduction : Production<RuleValue<AsmSigExpr>,AsmSigRuleExpr>, IAsmSigProduction
    {
        public AsmSigProduction(AsmSigExpr src, AsmSigRuleExpr dst)
            : base(src,dst)
        {

        }

        public static AsmSigProduction Empty => new AsmSigProduction(AsmSigExpr.Empty, AsmSigRuleExpr.Empty);
    }
}