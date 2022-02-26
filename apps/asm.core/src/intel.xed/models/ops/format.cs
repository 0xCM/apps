//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct XedModels
    {
        internal static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(" && ");
                ref readonly var c = ref skip(src,i);
                dst.Append(c.Format());
            }
        }

        internal static string format(in XedRuleExpr src)
        {
            var sep = src.Kind == XedRuleExprKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.LeftCriteria, dst);
            dst.Append(sep);
            render(src.RightCriteria, dst);
            return dst.Emit();
        }

    }
}