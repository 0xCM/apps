//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

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
            else if(IsNeq(src))
            {
                result = XedParsers.parse(src, out FieldConstraint x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

            }
            else if(IsAssign(src))
            {
                result = XedParsers.parse(src, out FieldAssign x);
                if(result)
                {
                    dst = x;
                }
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldAssign), src));

            }
            else if(IsCall(src))
            {
                result = XedParsers.parse(src, out Nonterminal x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
            }
            // else if(IsBfSpec(src))
            // {
            //     dst = new BitfieldSpec(src);
            // }
            return result;
        }

        public Outcome Parse(string src, out InstPatternBody dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src), Chars.Space));
            var count = parts.Length;
            dst = alloc<InstDefPart>(count);
            for(var i=0; i<count; i++)
            {
                ref var target = ref dst[i];
                ref readonly var part = ref skip(parts,i);
                result = parse(part, out target);
                if(result.Fail)
                    break;
            }

            return result;
        }
    }
}