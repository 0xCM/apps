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
            [MethodImpl(Inline), Op]
            public static SegField segfield(FieldKind field, string content)
                => new SegField(SegVar.parse(content), field);

            public static bool segfield(string src, out SegField dst)
            {
                dst = SegField.Empty;
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
                            dst = SegField.literal(field, data);
                        else
                            dst = new SegField(SegVar.parse(data), field);
                    }
                }
                else
                {
                    dst = new SegField(SegVar.parse(src), 0);
                    result = true;
                }

                return result;
            }
        }
    }
}