//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedPatterns
    {
        [MethodImpl(Inline), Op]
        public static bool opwidth(in PatternOp op, out OpWidth dst)
        {
            var result = op.Attribs.Search(OpClass.OpWidth, out var attrib);
            if(result)
                dst= attrib.AsOpWidth();
            else
            {
                if(nonterm(op, out var nt))
                {
                    var gpr = GprWidths.widths(nt.Kind);
                    result = gpr.IsNonEmpty;
                    if(result)
                        dst = gpr;
                    else
                        dst = OpWidth.Empty;
                }
                else
                {
                    dst = OpWidth.Empty;
                }
            }
            return result;
        }
    }
}