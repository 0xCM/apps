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
            var dst = EmptyString;
            switch(src.DataKind)
            {
                case CellDataKind.Error:
                case CellDataKind.Default:
                case CellDataKind.Wildcard:
                case CellDataKind.Literal:
                case CellDataKind.Null:
                {
                    if(src.Operator != 0 && src.Field != 0)
                        dst = string.Format("{0}{1}{2}", format(src.Field), format(src.Operator),src.AsLiteral());
                    else
                        dst = src.AsLiteral();
                }
                break;
            }

            if(text.empty(dst))
            {
                if(src.IsAssignment)
                    dst = format(src.AsAssignment());
                else if(src.IsComparison)
                    dst = format(src.AsCmp());
                else if(src.IsCall)
                    dst = format(src.AsCall());
                else if(src.IsBfSeg)
                    dst = format(src.AsBfSeg());
                else if(src.IsBfSpec)
                    dst = format(src.AsBfSpec());
                else
                    dst = string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.AsValue()));
            }

            return dst;
        }
    }
}