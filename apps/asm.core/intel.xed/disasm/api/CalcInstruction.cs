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
            ref readonly var content = ref src.Instruction.Content;
            if(text.nonempty(content))
            {
                var j = text.index(content, Chars.Space);
                if(j > 0)
                {
                    var expr = text.left(content,j);
                    if(!XedParsers.parse(expr, out dst.InstClass))
                    {
                        result = (false, AppMsg.ParseFailure.Format(nameof(dst.InstClass), content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(!XedParsers.parse(expr, out dst.InstForm))
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(dst.InstForm), expr));
                            return result;
                        }
                    }

                    dst.Props = XedDisasm.props(src);
                }
            }
            return result;
        }
    }
}