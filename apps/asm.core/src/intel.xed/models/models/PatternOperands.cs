//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        static string ConformRuleExpr(string src)
            => src.Replace("MOD[0b11] MOD=3", "MOD[0b11]");

        public readonly struct PatternOperands
        {
            public TextBlock Expr {get;}

            public Index<RuleOpSpec> Operands {get;}

            [MethodImpl(Inline)]
            public PatternOperands(string expr, RuleOpSpec[] operands)
            {
                Expr = ConformRuleExpr(text.despace(expr));
                Operands = operands;
            }

            public Index<PatternComponent> Componentize()
                => PatternComponent.components(Expr);

            public string Format()
                => string.Format("Pattern:{0}\nOperands:{1}", Expr, Operands);

            public override string ToString()
                => Format();
        }
    }
}