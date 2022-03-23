//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedDisasm;

    partial class XedDisasmSvc
    {
        public Outcome CalcInstruction(in DisasmLineBlock src, out DisasmInstruction dst)
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
                    if(Classes.Lookup(expr, out var @class))
                        dst.Class = @class;
                    else
                    {
                        result = (false, AppMsg.ParseFailure.Format(nameof(IClass), content));
                        return result;
                    }

                    var k = text.index(content, j+1, Chars.Space);
                    if(k > 0)
                    {
                        expr = text.inside(content, j, k);
                        if(Forms.Lookup(expr, out var form))
                            dst.Form = form;
                        else
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(IFormType), expr));
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