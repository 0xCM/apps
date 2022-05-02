//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedParsers;

    partial class XedRules
    {
        public readonly struct InstParser
        {
            public static Outcome field(string src, out CellValue dst)
            {
                dst = CellValue.Empty;
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
                else if(XedParsers.IsSeg(src))
                {
                    result = CellParser.parse(src, out InstSeg x);
                    if(result)
                        dst = x;
                }
                else if (XedParsers.IsExpr(src))
                {
                    result = CellParser.expr(src, out CellExpr x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(CellExpr), src));
                }
                else if(IsNonterm(src))
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
                    dst = a;
                }

                return result;
            }

            public static void parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<CellValue>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts,i);
                    result = field(part, out dst[i]);
                    if(result.Fail)
                        Errors.Throw(result.Message);
                }
            }
        }
    }
}