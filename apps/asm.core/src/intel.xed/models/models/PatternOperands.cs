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

            public Index<RuleOpSpec> Specs {get;}

            [MethodImpl(Inline)]
            public PatternOperands(string expr, RuleOpSpec[] operands)
            {
                Expr = ConformRuleExpr(text.despace(expr));
                Specs = operands;
            }

            public string Format()
                => string.Format("Pattern:{0}\nOperands:{1}", Expr, Specs);

            public override string ToString()
                => Format();
        }
    }
}