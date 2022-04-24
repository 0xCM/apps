//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly partial struct CellParser
        {
            public static Outcome parse(string src, out InstSeg dst)
            {
                var result = Outcome.Success;
                dst = InstSeg.Empty;
                var i = text.index(src, Chars.LBracket);
                var j = text.index(src, Chars.RBracket);
                result = i>0 && j>i;
                if(result)
                {
                    result = XedParsers.parse(text.left(src,i), out FieldKind field);
                    if(!result)
                        return false;

                    result = XedParsers.segdata(src, out var sd);
                    if(!result)
                        return result;

                    var literal = XedParsers.IsBinaryLiteral(sd);
                    if(!literal)
                    {
                        var vt = InstSegTypes.type(sd);
                        if(vt.IsNonEmpty)
                        {
                            dst = seg(field, vt);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        result = XedParsers.bitnumber(sd, out byte n, out byte value);
                        if(result)
                            dst = seg(field, n, value);
                    }
                }

                return result;
            }
        }
    }
}