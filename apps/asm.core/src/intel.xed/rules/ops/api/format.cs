//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using RTK = XedRules.RuleTokenKind;

    partial class XedRules
    {
        internal static string format(in RuleToken src)
        {
            var kind = src.Kind;
            var value = EmptyString;
            switch(kind)
            {
                case RTK.BinLit:
                    value = "0b" + src.AsBinaryLit().Format();
                break;
                case RTK.DecLit:
                    value = src.AsDecimalLit().ToString();
                break;
                case RTK.HexLit:
                    value = src.AsHexLit().Format(prespec:true,uppercase:true);
                break;
                case RTK.Constraint:
                    value = src.AsConstraint().Format();
                break;
                case RTK.FieldSeg:
                    value = src.AsFieldSeg().Format();
                break;
                case RTK.Macro:
                    value = src.AsMacro().Format();
                break;
                case RTK.Nonterm:
                    value = src.AsNonterm().Format();
                break;

            }
            return src.IsEmpty ? EmptyString : string.Format("<{0}:{1}>", value, src.Kind);
        }

        static string literal(FieldLiteralKind kind, byte src)
        {
            var val = EmptyString;
            switch(kind)
            {
                case FieldLiteralKind.BinaryLiteral:
                    val = "0b" + ((uint8b)(src)).Format();
                break;
                case FieldLiteralKind.DecimalLiteral:
                    val = src.ToString();
                break;
                case FieldLiteralKind.HexLiteral:
                    val = ((Hex8)(src)).Format(prespec:true, uppercase:true);
                break;
                default:
                    val = RP.Error;
                break;
            }
            return val;
        }
        internal static string format(FieldAssignment src)
            => src.Field == 0 ? "nothing" : string.Format("{0}={1}", FieldKinds[src.Field].Expr, src.Value.ToString());

        internal static string format(in NonterminalRule src)
            => format(src.Def);

        internal static string format(FieldConstraint src)
            => string.Format("{0}{1}{2}", format(src.Field), format(src.Kind), literal(src.LiteralKind,src.Value));

        internal static string format(BitfieldSeg src)
            => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", format(src.Field), src.Pattern);

        public static string format(RuleOperator src)
            => RuleOps[src].Expr.Text;

        public static string format(FieldKind src)
            => FieldKinds[src].Expr.Text;

        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

        public static string format(NonterminalKind src)
            => Nonterminals[src].Expr.Text;

        public static string format(RuleMacroKind src)
            => MacroKinds[src].Expr.Text;

        public static string format(NontermCall src)
            => string.Format("{0}()", format(src.Kind));

        internal static string format(in MacroSpec src)
        {
            var dst = text.buffer();
            dst.AppendFormat("{0} -> ", MacroKinds[src.Name].Expr);
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