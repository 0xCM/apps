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

    using static XedModels;

    public struct XedRuleExpr
    {
        public XedRuleKind Kind;

        public TextBlock Premise;

        public TextBlock Consequent;

        public Index<RuleCriterion> LeftCriteria {get;}

        public Index<RuleCriterion> RightCriteria {get;}

        [MethodImpl(Inline)]
        public XedRuleExpr(XedRuleKind kind, string premise, string consequent, Index<RuleCriterion> left, Index<RuleCriterion> rigth)
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

    partial struct XedModels
    {
        internal static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
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

        internal static string format(in XedRuleExpr src)
        {
            var sep = src.Kind == XedRuleKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.LeftCriteria, dst);
            dst.Append(sep);
            render(src.RightCriteria, dst);
            return dst.Emit();
        }
    }
}