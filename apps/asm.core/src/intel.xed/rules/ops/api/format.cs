//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        internal static string format(in MacroSpec src)
        {
            var dst = text.buffer();
            dst.AppendFormat("{0} -> ", MacroNames[src.Name].Expr);
            var assignments = src.Assignments;
            var count = assignments.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref assignments[i];
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(a.Format());
            }
            return dst.Emit();
        }

        internal static string format(in RuleTable src)
        {
            var dst = text.buffer();
            dst.AppendLine(sig(src));
            var expressions = src.Expressions.View;
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, skip(expressions, i).Format());
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        internal static string format(in XedRuleExpr src)
        {
            var sep = src.Kind == RuleFormKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.Premise, dst);
            dst.Append(sep);
            render(src.Consequent, dst);
            return dst.Emit();
        }

        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
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
    }
}