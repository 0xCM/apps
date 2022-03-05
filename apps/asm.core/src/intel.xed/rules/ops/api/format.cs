//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;

    using RTK = XedRules.RuleTokenKind;
    using AK = XedRules.OperandAttribKind;

    partial class XedRules
    {
        public static string format(OperandAttrib src)
        {
            var dst = EmptyString;
            switch(src.Kind)
            {
                case AK.Action:
                     dst = OpActions[src.AsAction()].Expr.Text;
                break;
                case AK.OpWidth:
                    dst = OpWidthKinds[src.AsOpWidth()].Expr.Text;
                break;

                case AK.PtrWidth:
                    dst = PointerWidthKinds[src.AsPtrWidth()].Expr.Text;
                break;

                case AK.DataType:
                    dst = DataTypes[src.AsDataType()].Expr.Text;
                break;

                case AK.Nonterminal:
                     dst = Nonterminals[src.AsNonTerm()].Expr.Text;
                break;

                case AK.Visibility:
                    dst = Supressions[src.AsVisiblity()].Expr.Text;
                break;

                case AK.RegLiteral:
                    dst = src.AsRegLiteral().ToString();
                break;

                case AK.Scale:
                    dst = src.AsScale().Format();
                break;

                case AK.RegResolver:
                    dst = src.AsRegResolver().Format();
                break;

                case AK.Macro:
                    dst = src.AsMacro().ToString();
                break;

            }
            return dst;
        }

        public static string format(AsmOcValue src)
        {
            var data = src.Trimmed;
            var dst = "0x00";
            switch(data.Length)
            {
                case 1:
                    dst = string.Format("0x{0:X2}", skip(data,0));
                break;
                case 2:
                    dst = string.Format("0x{0:X2} 0x{1:X2}", skip(data,0), skip(data,1));
                break;
                case 3:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2}", skip(data,0), skip(data,1), skip(data,2));
                break;
                case 4:
                    dst = string.Format("0x{0:X2} 0x{1:X2} 0x{2:X2} 0x{3:X2}", skip(data,0), skip(data,1), skip(data,2), skip(data,3));
                break;
            }
            return dst;
        }

        public static string format(in RuleToken src, bool showkind)
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
                case RTK.Assignment:
                    value = src.AsAssignment().Format();
                break;
            }

            return src.IsEmpty
                ? EmptyString
                : showkind
                ? string.Format("<{0}:{1}>", value, src.Kind)
                : value;
        }

        public static string format(in RuleToken src)
            => format(src, false);

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

        [MethodImpl(Inline), Op]
        public static string format(RuleOperator src)
            => RuleOps[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(FieldKind src)
            => FieldKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(NonterminalKind src)
            => Nonterminals[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(RuleMacroKind src)
            => MacroKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(OpCodeKind src)
            => OcKindIndex[ocindex(src)].Expr.Text;

        public static string format(NontermCall src)
            => string.Format("{0}()", format(src.Kind));

        internal static string format(in MacroSpec src)
        {
            var dst = text.buffer();
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