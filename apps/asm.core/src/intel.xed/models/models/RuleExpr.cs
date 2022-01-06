//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct XedModels
    {
        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;
            if(count > 1)
                dst.Append(Chars.LParen);

            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Comma);
                ref readonly var c = ref skip(src,i);
                dst.Append(c.Format());
            }

            if(count > 1)
                dst.Append(Chars.RParen);
        }

        static string format(in RuleExpr src)
        {
            var sep = src.Kind == RuleExprKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.LeftCriteria, dst);
            dst.Append(sep);
            render(src.RightCriteria, dst);
            return dst.Emit();
        }

        public struct RuleExpr
        {
            public RuleExprKind Kind;

            public TextBlock Premise;

            public TextBlock Consequent;

            public Index<RuleCriterion> LeftCriteria {get;}

            public Index<RuleCriterion> RightCriteria {get;}

            [MethodImpl(Inline)]
            public RuleExpr(RuleExprKind kind, string premise, string consequent, Index<RuleCriterion> left, Index<RuleCriterion> rigth)
            {
                Kind = kind;
                Premise = premise;
                Consequent = consequent;
                LeftCriteria = left;
                RightCriteria = rigth;
            }

            public string Format()
                => format(this);

            public override string ToString()
                => Format();
        }
    }
}