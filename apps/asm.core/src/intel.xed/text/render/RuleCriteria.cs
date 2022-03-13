//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedRender
    {
        public static string format(ImmFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}{1}[i/{2}]", "UIMM", src.Index, src.Width);

        public static string format(DispFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}[{1}/{2}]", "DISP", src.Kind, src.Width);

        public static string format(RuleCall src)
            => src.Target.IsEmpty ? EmptyString : string.Format("{0}()", src.Target);

        public static string format(BitfieldSeg src)
            => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

        public static string format(in RuleCriterion src)
        {
            var dst = EmptyString;
            if(src.IsNontermCall)
                dst = format(src.AsNontermCall());
            else if(src.IsGroupCall)
                dst = format(src.AsGroupCall());
            else if(src.IsResolvableCall)
                dst = format(src.AsResolvableCall());
            else if(src.Operator == RuleOperator.Seg)
                dst = format(src.AsFieldSeg());
            else if(src.Operator == RuleOperator.Literal)
                dst = src.AsLiteral();
            else if(src.IsError)
            {
                dst = "error";
            }
            else
            {
                dst = format(src.Field);
                if(src.Operator != 0)
                    dst += format(src.Operator);
                dst += format(src.AsValue());
            }
            return dst;
        }
    }
}