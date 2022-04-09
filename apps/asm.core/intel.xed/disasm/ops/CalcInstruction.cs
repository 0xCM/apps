//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static Outcome CalcInstruction(in DisasmLineBlock src, out DisasmInstruction dst)
        {
            var result = Outcome.Success;
            dst = default(DisasmInstruction);
            ref readonly var content = ref src.Props.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(!XedParsers.parse(expr, out dst.Class))
                    {
                        result = (false, AppMsg.ParseFailure.Format(nameof(dst.Class), content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(!XedParsers.parse(expr, out dst.Form))
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(dst.Form), expr));
                            return result;
                        }
                    }

                    DisasmParse.parse(src, out dst.Props);
                }
            }
            return result;
        }
    }
}