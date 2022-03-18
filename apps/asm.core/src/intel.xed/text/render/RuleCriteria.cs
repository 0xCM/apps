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
        {
            if(src.IsEmpty)
            {
                return EmptyString;
            }
            else
            {
                if(src.Field == 0)
                    return string.Format("{0}()", src.Target.Format());
                else
                    return string.Format("{0}{1}{2}()", format(src.Field), format(src.Operator), src.Target.Format());
            }
        }

        public static string format(BitfieldSeg src)
            => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

        public static string format(BitfieldSpec src)
            => src.Pattern.Format();

        public static string format(in RuleCriterion src)
        {
            if(src.IsNonterminal)
            {
                if(src.Field != 0 && src.Operator != 0)
                    return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), src.AsNonterminal());
                else
                    return format(src.AsNonterminal());
            }

            switch(src.DataKind)
            {
                case CellDataKind.Error:
                case CellDataKind.Default:
                case CellDataKind.Wildcard:
                case CellDataKind.Literal:
                case CellDataKind.Null:
                {
                    if(src.Operator != 0 && src.Field != 0)
                        return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), src.AsLiteral());
                    else
                        return src.AsLiteral();
                }
            }

            if(src.IsAssignment)
                return format(src.AsAssignment());
            else if(src.IsComparison)
                return format(src.AsCmp());
            else if(src.IsCall)
                return format(src.AsCall());
            else if(src.IsBfSeg)
                return format(src.AsBfSeg());
            else if(src.IsBfSpec)
                return format(src.AsBfSpec());
            else if(src.IsNonterminal)
                return format(src.AsNonterminal());
            else
                return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.AsValue()));
        }
    }
}