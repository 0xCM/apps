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
        public static string format(in RuleCriterion src)
        {
            if(src.IsCall)
                return format(src.AsCall());
            else if(src.IsNonterminal)
            {
                var fmt = src.AsNonterminal().Format();
                if(src.Field != 0 && src.Operator != 0)
                    return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), fmt);
                else
                    return fmt;
            }
            else if(src.IsLiteral)
                return src.AsLiteral().Format();
            else if(src.IsAssignment)
                return format(src.AsAssignment());
            else if(src.IsComparison)
                return format(src.AsCmp());
            else if(src.IsBfSeg)
                return format(src.AsBfSeg());
            else if(src.IsBfSpec)
                return format(src.AsBfSpec());
            else
                return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.AsValue()));
        }
    }
}