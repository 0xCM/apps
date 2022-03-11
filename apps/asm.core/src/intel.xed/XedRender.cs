//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static Asm.IntelXed;

    using R = XedRules;

    using static core;

    using PW = XedModels.PointerWidthKind;
    using TK = XedRules.RuleTokenKind;
    using K = XedRules.RuleOpClass;
    using FC = XedRules.FormatCode;

    public class XedRender
    {
        public static XedRender create()
            => new XedRender();

        public static string format(RuleOpAttrib src)
        {
            var dst = EmptyString;
            switch(src.Kind)
            {
                case K.Action:
                    dst = format(src.AsAction());
                break;
                case K.OpWidth:
                    dst = format(src.AsOpWidth());
                break;

                case K.PtrWidth:
                    dst = format(src.AsPtrWidth());
                break;

                case K.ElementType:
                    dst = format(src.AsElementType());
                break;

                case K.EncGroup:
                    dst = format(src.AsEncodingGroup());
                break;

                case K.Common:
                    dst = format(src.AsCommon());
                break;

                case K.Modifier:
                    dst = format(src.AsModifier());
                break;

                case K.Nonterminal:
                    dst = format(src.AsNonTerm());
                break;

                case K.Visibility:
                    dst = format(src.AsVisiblity());
                break;

                case K.RegLiteral:
                    dst = format(src.AsRegLiteral());
                break;

                case K.Scale:
                    dst = src.AsScale().Format();
                break;

                case K.Macro:
                    dst = src.AsMacro().ToString();
                break;

            }
            return dst;
        }

        public static string format(ValueSelector src)
        {
            var dst = EmptyString;
            switch(src.Kind)
            {
                case ValueSelectorKind.EncodingGroup:
                    dst = format((EncodingGroup)src.Spec);
                break;
                case ValueSelectorKind.Nonterminal:
                    dst = format((NonterminalKind)src.Spec);
                break;
                case ValueSelectorKind.RegLiteral:
                    dst = format((XedRegId)src.Spec);
                break;
                case ValueSelectorKind.Literal:
                    dst = src.Spec.ToString();
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
                    value = format(src.AsConstraint());
                break;
                case TK.FieldSeg:
                    value = src.AsFieldSeg().Format();
                break;
                case TK.Macro:
                    value = format(src.AsMacro());
                break;
                case TK.Nonterm:
                    value = format(src.AsNonterm());
                break;
                case TK.Assignment:
                    value = format(src.AsAssignment());
                break;
            }

            return src.IsEmpty
                ? EmptyString
                : showkind
                ? string.Format("<{0}:{1}>", value, src.Kind)
                : value;
        }

        public static string format(in DisasmOpDetails src)
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

        public static string format(in EncodingOffsets src)
        {
            var dst = text.buffer();
            dst.Append(Chars.LBrace);
            dst.AppendFormat("{0}={1}", "opcode", src.OpCode);
            if(src.ModRm > 0)
                dst.AppendFormat(", {0}={1}", "modrm", src.ModRm);
            if(src.Sib > 0)
                dst.AppendFormat(", {0}={1}", "sib",  src.Sib);
            if(src.Disp > 0)
                dst.AppendFormat(", {0}={1}", "disp", src.Disp);
            if(src.Imm0 > 0)
                dst.AppendFormat(", {0}={1}", "imm0", src.Imm0);
            if(src.Imm1 > 0)
                dst.AppendFormat(", {0}={1}", "imm1", src.Imm1);
            dst.Append(Chars.RBrace);
            return dst.Emit();
        }

        public static string format(in RuleToken src)
            => format(src, false);

        public static string format(RuleOpModKind src)
            => OpMods[src].Expr.Text;

        public static string format(RuleOpName src)
            => OpNames[src].Expr.Text;

        public static string format(RuleOperator src)
            => RuleOps[src].Expr.Text;

        public static string format(BCastKind src)
            => BCastFormatter.format(src);

        public static string format(XedRegId src)
            => XedRegs[src].Expr.Text;

        public static string format(OperandAction src)
            => OpActions[src].Expr.Text;

        public static string format(EncodingGroup src)
            => EncodingGroups[src].Expr.Text;

        public static string format(ChipCode src)
            => ChipCodes[src].Expr.Text;

        public static string format(VexClass src)
            => VexClasses.Format(src);

        public static string format(VexKind src)
            => VexKinds.Format(src);

        public static string format(IClass src)
            => Classes[src].Expr.Text;

        public static string format(FieldKind src)
            => FieldKinds[src].Expr.Text;

        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

        public static string format(NonterminalKind src)
            => Nonterminals[src].Expr.Text;

        public static string format(RuleMacroKind src)
            => MacroKinds[src].Expr.Text;

        public static string format(AttributeKind src)
            => AttribKinds[src].Expr.Text;

        public static string format(BCast8Kind src)
            => BCast8.Format(src);

        public static string format(BCast16Kind src)
            => BCast16.Format(src);

        public static string format(BCast32Kind src)
            => BCast32.Format(src);

        public static string format(BCast64Kind src)
            => BCast64.Format(src);

        public static string format(VisibilityKind src)
            => VisKind.Format(src);

        public static string format(OperandWidthCode src)
            => OpWidthKinds[src].Expr.Text;

        public static string format(PointerWidthKind src)
            => src switch{
                PW.Byte => "b",
                PW.Word => "w",
                PW.DWord => "l",
                PW.QWord => "q",
                PW.XmmWord => "x",
                PW.YmmWord => "y",
                PW.ZmmWord => "z",
                _ => EmptyString
            };

        public static string format(ElementKind src)
            => ElementTypes[src].Expr.Text;

        public static string format(OpVisibility src)
            => OpVis[src].Expr.Text;

        public static string format(OpCodeKind src)
            => OcKindIndex[ocindex(src)].Expr.Text;

        public static string format(DispExpr src)
            => DispKinds[src.Kind].Expr.Text;

        public static string format(EOSZ src)
            => EoszKinds[src].Expr.Text;

        public static string format(EASZ src)
            => EaszKinds[src].Expr.Text;

        public static string format(RoundingKind src)
            => RoundingKinds[src].Expr.Text;

        public static string format(ModeKind src)
            => ModeKinds.Format(src);

        public static string format(in RuleTermTable src)
        {
            var dst = text.buffer();
            dst.AppendLine(sig(src));
            var expressions = src.Expressions.View;
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, format(skip(expressions, i)));
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

                dst.Append(format(a));
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
                dst.Append(format(skip(src,i)));
            }
        }

        static EnumFormatter<BCast8Kind> BCast8 = new();

        static EnumFormatter<BCast16Kind> BCast16 = new();

        static EnumFormatter<BCast32Kind> BCast32 = new();

        static EnumFormatter<BCast64Kind> BCast64 = new();

        static EnumFormatter<ModeKind> ModeKinds = new();

        static EnumFormatter<VisibilityKind> VisKind = new();

        static EnumFormatter<VexClass> VexClasses = new();

        static EnumFormatter<VexKind> VexKinds = new();

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

        static Symbols<OperandWidthCode> OpWidthKinds;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static Symbols<ElementKind> ElementTypes;

        static Symbols<RuleOpName> OpNames;

        static Symbols<OpVisibility> OpVis;

        static Symbols<EncodingGroup> EncodingGroups;

        static Symbols<RuleOpModKind> OpMods;

        static Symbols<IClass> Classes;

        static Symbols<EASZ> EaszKinds;

        static Symbols<EOSZ> EoszKinds;

        static Symbols<RoundingKind> RoundingKinds;

        static XedRender()
        {
            FieldKinds = Symbols.index<FieldKind>();
            MacroKinds = Symbols.index<RuleMacroKind>();
            BCastKinds = Symbols.index<BCastKind>();
            ChipCodes = Symbols.index<ChipCode>();
            XedRegs = Symbols.index<XedRegId>();
            OpWidthKinds = Symbols.index<OperandWidthCode>();
            InstClasses = Symbols.index<IClass>();
            RuleOps = Symbols.index<RuleOperator>();
            DispKinds = Symbols.index<DispExprKind>();
            ConstraintKinds = Symbols.index<ConstraintKind>();
            Nonterminals = Symbols.index<NonterminalKind>();
            OcKindIndex = Symbols.index<OpCodeIndex>();
            OpActions = Symbols.index<OperandAction>();
            OpNames = Symbols.index<RuleOpName>();
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
            OpVis = Symbols.index<OpVisibility>();
            ElementTypes = Symbols.index<ElementKind>();
            EncodingGroups = Symbols.index<EncodingGroup>();
            AttribKinds = Symbols.index<AttributeKind>();
            OpMods = Symbols.index<RuleOpModKind>();
            Classes = Symbols.index<IClass>();
            EaszKinds = Symbols.index<EASZ>();
            EoszKinds = Symbols.index<EOSZ>();
            RoundingKinds = Symbols.index<RoundingKind>();
       }

        public static string format(ImmFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}{1}[i/{2}]", "UIMM", src.Index, src.Width);

        public static string format(DispFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}[{1}/{2}]", "DISP", src.Kind, src.Width);

        public static string format(RuleCall src)
            => src.Target.IsEmpty ? EmptyString : string.Format("{0}()", src.Target);

        public static string format(in RuleCriterion src)
        {
            var dst = EmptyString;
            if(src.Operator == RuleOperator.Call)
                dst = format(src.AsCall());
            else if(src.Field == FieldKind.UIMM0 || src.Field == FieldKind.UIMM1)
                dst = format(src.AsImmField());
            else if(src.Field == FieldKind.DISP)
                dst = format(src.AsDispField());
            else
            {
                dst = format(src.Field);
                if(src.Operator != 0)
                    dst += format(src.Operator);
                dst += format(src.AsValue());
            }
            return dst;
        }

        public static string format(in RuleTable src)
        {
            var dst = text.buffer();
            dst.AppendLine(sig(src));
            var expressions = src.Expressions.View;
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, format(skip(expressions, i)));
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        public static string format(in RuleExpr src)
        {
            var sep = " <=> ";
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
                dst.Append(format(skip(src,i)));
            }
        }

        public static string format(R.FieldValue src)
        {
            var dst = EmptyString;
            if(src.IsEmpty)
                return EmptyString;

            var data = bytes(src.Data);
            var code = fcode(src.Kind);

            switch(code)
            {
                case FC.Text:
                    dst = ((NameResolver)((int)src.Data)).Format();
                    break;
                case FC.B1:
                {
                    bit x = first(data);
                    dst = x.Format();
                }
                break;
                case FC.B2:
                {
                    uint2 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B3:
                {
                    uint3 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B4:
                {
                    uint4 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B5:
                {
                    uint5 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B6:
                {
                    uint6 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B7:
                {
                    uint7 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B8:
                {
                    uint8b x = first(data);
                    dst = format(x);
                }
                break;

                case FC.U2:
                {
                    byte x = (byte)(first(data) & 0b11);
                    dst = format(x);
                }
                break;

                case FC.U3:
                {
                    byte x = (byte)(first(data) & 0b111);
                    dst = format(x);
                }
                break;

                case FC.U4:
                {
                    byte x = (byte)(first(data) & 0b1111);
                    dst = format(x);
                }
                break;

                case FC.U5:
                {
                    byte x = (byte)(first(data) & 0b11111);
                    dst = format(x);
                }
                break;

                case FC.U8:
                {
                    var x = first(data);
                    dst = format(x);
                }
                break;
                case FC.U16:
                {
                    var x = @as<ushort>(data);
                    dst = format(x);
                }
                break;
                case FC.U32:
                {
                    var x = @as<uint>(data);
                    dst = format(x);
                }
                break;
                case FC.U64:
                {
                    var x = @as<ulong>(data);
                    dst = format(x);
                }
                break;

                case FC.I8:
                {
                    var x = @as<sbyte>(data);
                    dst = format(x);
                }
                break;
                case FC.I16:
                {
                    var x = @as<short>(data);
                    dst = format(x);
                }
                break;
                case FC.I32:
                {
                    var x = @as<int>(data);
                    dst = format(x);
                }
                break;
                case FC.I64:
                {
                    var x = @as<long>(data);
                    dst = format(x);
                }
                break;

                case FC.X2:
                {
                    Hex2 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X3:
                {
                    Hex3 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X4:
                {
                    Hex4 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X5:
                {
                    Hex5 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X6:
                {
                    Hex6 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X7:
                {
                    Hex7 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X8:
                {
                    Hex8 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X16:
                {
                    Hex16 x = @as<ushort>(data);
                    dst = format(x);
                }
                break;
                case FC.X32:
                {
                    Hex32 x = @as<uint>(data);
                    dst = format(x);
                }
                break;
                case FC.X64:
                {
                    Hex64 x = @as<ulong>(data);
                    dst = format(x);
                }
                break;

                case FC.Disp:
                {
                    Disp64 x = @as<long>(data);
                    dst = x.Format();
                }
                break;

                case FC.Broadcast:
                {
                    var x = @as<BCastKind>(data);
                    dst = format(x);
                }
                break;
                case FC.Chip:
                {
                    var x = @as<ChipCode>(data);
                    dst = format(x);
                }
                break;
                case FC.Reg:
                {
                    var x = @as<XedRegId>(data);
                    dst = format(x);
                }
                break;
                case FC.InstClass:
                {
                    var x = @as<IClass>(data);
                    dst = format(x);
                }
                break;
                case FC.MemWidth:
                {
                    var x = @as<ushort>(data);
                    dst = x.ToString();
                }
                break;
                case FC.EnumSymbol:
                break;
                case FC.EnumValue:
                break;
                case FC.EnumName:
                break;

            }
            return dst;
        }


        static string format(uint2 src)
            => src.Format();

        static string format(uint3 src)
            => src.Format();

        static string format(uint4 src)
            => src.Format();

        static string format(uint5 src)
            => src.Format();

        static string format(uint6 src)
            => src.Format();

        static string format(uint7 src)
            => src.Format();

        static string format(uint8b src)
            => src.Format();

        static string format(sbyte src)
            => src.ToString();

        static string format(short src)
            => src.ToString();

        static string format(int src)
            => src.ToString();

        static string format(long src)
            => src.ToString();

        static string format(byte src)
            => src.ToString();

        static string format(ushort src)
            => src.ToString();

        static string format(uint src)
            => src.ToString();

        static string format(ulong src)
            => src.ToString();

        static string format(Hex2 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex3 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex4 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex5 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex6 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex7 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex8 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex16 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex32 src)
            => src.Format(prespec:true, uppercase:true);

        static string format(Hex64 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(BitfieldSeg src)
            => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

        public static string format(FieldAssign src)
            => src.Field == 0 ? "nothing" : string.Format("{0}={1}", format(src.Field), src.Value);

        public static string format(FieldCmp src)
            => src.IsEmpty ? EmptyString
                : string.Format("{0}{1}{2}",
                    format(src.Left.Kind),
                    format(src.Operator),
                    format(src.Left)
                    );

        public static string format(in NonterminalRule src)
            => format(src.Table);

        public static string format(FieldConstraint src)
            => string.Format("{0}{1}{2}",
                    format(src.Field),
                    format(src.Kind),
                    literal(src.LiteralKind, src.Value)
                    );

        public static string format(NontermCall src)
            => string.Format("{0}()", format(src.Kind));

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

    }
}