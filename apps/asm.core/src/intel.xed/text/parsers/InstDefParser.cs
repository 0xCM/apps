//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedParsers
    {
        public static Outcome parse(string src, out InstDefPart dst)
        {
            dst = InstDefPart.Empty;
            Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
            if(IsHexLiteral(src))
            {
                result = XedParsers.parse(src, out Hex8 x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
            }
            else if(IsBinaryLiteral(src))
            {
                result = XedParsers.parse(src, out uint5 x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

            }
            else if(IsBfSeg(src))
            {
                result = XedParsers.parse(src, out BitfieldSeg x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(BitfieldSeg), src));
            }
            else if(IsCmpNeq(src))
            {
                result = XedParsers.parse(src, out FieldConstraint x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

            }
            else if(IsAssignment(src))
            {
                result = XedParsers.parse(src, out FieldAssign x);
                if(result)
                {
                    dst = x;
                }
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldAssign), src));

            }
            else if(IsNonterminal(src))
            {
                result = XedParsers.parse(src, out Nonterminal x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
            }
            else if (XedParsers.parse(src, out byte a))
            {
                result = true;
                dst = new(a);
            }

            return result;
        }
    }
}