//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static core;

    using TK = XedRules.RuleTokenKind;

    public class XedFormatters
    {
        public static XedFormatters create()
            => new XedFormatters();

        public static string format(in RuleToken src, bool showkind)
        {
            var kind = src.Kind;
            var value = EmptyString;
            switch(kind)
            {
                case TK.BinLit:
                    value = "0b" + src.AsBinaryLit().Format();
                break;
                case TK.DecLit:
                    value = src.AsDecimalLit().ToString();
                break;
                case TK.HexLit:
                    value = src.AsHexLit().Format(prespec:true,uppercase:true);
                break;
                case TK.Constraint:
                    value = src.AsConstraint().Format();
                break;
                case TK.FieldSeg:
                    value = src.AsFieldSeg().Format();
                break;
                case TK.Macro:
                    value = src.AsMacro().Format();
                break;
                case TK.Nonterm:
                    value = src.AsNonterm().Format();
                break;
                case TK.Assignment:
                    value = src.AsAssignment().Format();
                break;
            }

            return src.IsEmpty
                ? EmptyString
                : showkind
                ? string.Format("<{0}:{1}>", value, src.Kind)
                : value;
        }

        public static string format(in OperandDetails src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var d = ref src[i];
                if(i==0)
                    dst.AppendFormat("{0} |", d);
                else
                    dst.AppendFormat("{0}| ", d);
            }

            return dst.Emit();
        }

        public static string format(in RuleToken src)
            => format(src, false);

        [MethodImpl(Inline), Op]
        public static string format(RuleOperator src)
            => RuleOps[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(XedRegId src)
            => src.ToString();

        [MethodImpl(Inline), Op]
        public static string format(OperandAction src)
            => OpActions[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(EncodingGroup src)
            => EncodingGroups[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(FieldKind src)
            => FieldKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(TextPropKind src)
            => TextProps[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(NonterminalKind src)
            => src == 0 ? EmptyString : Nonterminals[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(RuleMacroKind src)
            => MacroKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(AttributeKind src)
            => AttribKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(OperandWidthKind src)
            => OpWidthKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(PointerWidthKind src)
            => PointerWidthKinds[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(ElementType src)
            => ElementTypes[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(in OpVisiblity src)
            => OpVis[src].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(OpCodeKind src)
            => OcKindIndex[ocindex(src)].Expr.Text;

        [MethodImpl(Inline), Op]
        public static string format(in DispExpr src)
            => DispKinds[src.Kind].Expr.Text;

        public static string format(in RuleTermTable src)
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

        public static string format(in RuleTermExpr src)
        {
            var sep = src.Kind == RuleFormKind.EncodeStep ? " -> " : " | ";
            var dst = text.buffer();
            render(src.Premise, dst);
            dst.Append(sep);
            render(src.Consequent, dst);
            return dst.Emit();
        }

        public static string format(in MacroSpec src)
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

        public static string format(in RuleTerm src)
        {
            if(src.Operator == RuleOperator.Call)
                return src.Value;
            else if(src.Operator != 0)
                return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), src.Value);
            else
                return string.Format("{0}", src.Value);
        }

        public static string format(RuleSig src)
            => string.Format("{0} {1}()", src.ReturnType, src.Name);

        static void render(ReadOnlySpan<RuleTerm> src, ITextBuffer dst)
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

        static Symbols<AttributeKind> AttribKinds;

        static Symbols<FieldKind> FieldKinds;

        static Symbols<RuleMacroKind> MacroKinds;

        static Symbols<BCastKind> BCastKinds;

        static Symbols<ChipCode> ChipCodes;

        static Symbols<XedRegId> XedRegs;

        static Symbols<IClass> InstClasses;

        static Symbols<RuleOperator> RuleOps;

        static Symbols<DispExprKind> DispKinds;

        static Symbols<ConstraintKind> ConstraintKinds;

        static Symbols<NonterminalKind> Nonterminals;

        static Symbols<OpCodeIndex> OcKindIndex;

        static Symbols<OperandAction> OpActions;

        static Symbols<OperandWidthKind> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static Symbols<ElementType> ElementTypes;

        static Symbols<RuleOpName> OpNames;

        static Symbols<OpVisiblity> OpVis;

        static Symbols<EncodingGroup> EncodingGroups;

        static Symbols<TextPropKind> TextProps;

        static XedFormatters()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroKinds = Symbols.index<RuleMacroKind>();
            BCastKinds = Symbols.index<BCastKind>();
            ChipCodes = Symbols.index<ChipCode>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthKind>();
            InstClasses = Symbols.index<IClass>();
            RuleOps = Symbols.index<RuleOperator>();
            DispKinds = Symbols.index<DispExprKind>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NonterminalKind>();
            OcKindIndex = Symbols.index<OpCodeIndex>();
            OpActions = Symbols.index<OperandAction>();
            OpNames = Symbols.index<RuleOpName>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            OpVis = Symbols.index<OpVisiblity>();
            ElementTypes = Symbols.index<ElementType>();
            EncodingGroups = Symbols.index<EncodingGroup>();
            AttribKinds = Symbols.index<AttributeKind>();
            TextProps = Symbols.index<TextPropKind>();
       }
    }
}