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

        public static string format(in RuleCriterion src)
        {
            var dst = EmptyString;
            if(src.IsError)
                dst = "error";
            else if(src.IsCall)
                dst = format(src.AsCall());
            else if(src.IsBitfieldSeg)
                dst = format(src.AsFieldSeg());
            else if(src.IsAssignment)
                dst = format(src.AsAssignment());
            else if(src.IsComparison)
                dst = format(src.AsCmp());
            else if(src.IsLiteral)
                dst = src.AsLiteral();
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