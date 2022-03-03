//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public static string format(BitfieldSeg src)
            => string.Format("{0}[{1}]", format(src.Field), src.Pattern);

        public static string format(RuleOperator src)
            => RuleOps[src].Expr.Text;

        public static string format(FieldKind src)
            => FieldKinds[src].Expr.Text;

        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

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

        internal static string format(in RuleCriterion src)
        {
            if(src.Operator == RuleOperator.Call)
                return string.Format("{0}()", src.Value);
            else if(src.Operator != 0)
                return string.Format("{0}{1}{2}", Symbols.expr(src.Field), Symbols.expr(src.Operator), src.Value);
            else
                return string.Format("{0}", src.Value);
        }

        internal static string format(in DispExpr src)
            => DispKinds[src.Kind].Expr.Text;

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

        internal static string format(in RuleExpr src)
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