//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial struct CellParser
        {
            public static bool seg(string src, out FieldSeg dst)
            {
                dst = FieldSeg.Empty;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                var result = i>0 && j>i;
                if(result)
                {
                    XedParsers.parse(text.left(src,i), out FieldKind field);
                    XedParsers.segdata(src, out var data);
                    result = field != 0 && text.nonempty(data);
                    if(result)
                    {
                        var literal = XedParsers.IsBinaryLiteral(data);
                        if(literal)
                            dst = FieldSeg.literal(field, data);
                        else
                            dst = FieldSeg.symbolic(field, data);
                    }
                }
                else
                {
                    dst = FieldSeg.symbolic(src);
                    result = true;
                }

                return result;
            }
        }
    }
}