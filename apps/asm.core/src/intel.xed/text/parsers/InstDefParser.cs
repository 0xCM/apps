//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedRules.SyntaxLiterals;
    using static core;

    partial class XedParsers
    {
        public readonly struct InstDefParser
        {
            public static InstDefParser Service => default;

            public Outcome Parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstDefPart>(count);
                for(var i=0; i<count; i++)
                {
                    ref var target = ref dst[i];
                    result = Parse(skip(parts,i), out target);
                    if(result.Fail)
                        break;
                }

                return result;
            }

            Outcome Parse(string src, out InstDefPart dst)
            {
                dst = InstDefPart.Empty;
                Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
                if(IsHexLiteral(src))
                {
                    result = parse(src, out Hex8 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
                }
                else if(IsBinaryLiteral(src))
                {
                    result = parse(src, out uint5 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

                }
                else if(IsBitfieldSeg(src))
                {
                    result = parse(src, out BitfieldSeg x);
                    if(result)
                        dst = x;
                }
                else if(IsNeq(src))
                {
                    result = parse(src, out FieldConstraint x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

                }
                else if(IsAssign(src))
                {
                    result = parse(src, out FieldAssign x);
                    if(result)
                        dst = x;
                }
                else if(IsCall(src))
                {
                    result = parse(src, out Nonterminal x);
                    if(result)
                        dst = x;
                }
                return result;
            }
        }
    }
}