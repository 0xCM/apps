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
    using static core;

    using PW = XedModels.PointerWidthKind;
    using R = XedRules;

    partial class XTend
    {
    }

    public partial class XedRender
    {
        public static string format(OpCodeIndex src, FormatCode fc = FormatCode.Expr)
            => format(OcKindIndex, src, fc);

        public static string format(EOSZ src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize(src) : format(EoszKinds,src,fc);

        public static string format(DispExpr src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? src.DispWidth.ToString() : format(DispKinds,src,fc);

        public static string format(EASZ src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize(src) : format(EaszKinds,src,fc);

        public static string format(ModeKind src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize((byte)src + 1) : format(ModeKinds,src,fc);

        public static string format(SMode src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize((byte)src + 1) : format(SModes,src,fc);

        public static string format(VexClass src, FormatCode fc = FormatCode.Expr)
            => format(VexClasses,src,fc);

        public static string format(VexKind src, FormatCode fc = FormatCode.Expr)
            => format(VexKinds, src, fc);

        public static string format(MASK src, FormatCode fc = FormatCode.Expr)
            => format(MaskCodes,src,fc);

        public static string format(R.FieldValue src)
            => XedFields.format(src);

        public static string format(FieldConstraint src)
            => XedFields.format(src);

        public static string format(in RuleTableCell src)
            => src.IsEmpty ? EmptyString : format(src.Criterion);

        public static string format(AsmOcValue src)
            => AsmOcValue.format(src);

        public static string format(in MacroExpansion src)
        {
            if(src.Value.IsEmpty)
                return EmptyString;
            else if(src.Operator == 0)
                return format(src.Field);
            else
                return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.Value));
        }

        public static string format(in InstPatternBody src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }

        public static void render(in InstPatternBody src, ITextBuffer dst)
        {
            for(var i=0; i<src.PartCount; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(format(src[i]));
            }
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

        public static string format(RuleOpName src)
            => OpNames[src].Expr.Text;

        public static string format(RuleOperator src)
            => RuleOps.Format(src);

        public static string format(BCastKind src)
            => BCastFormatter.format(src);

        public static string format(RuleOpModKind src)
            => OpModKinds.Format(src);

        public static string format(VexMapKind src)
            => VexMap.Format(src);

        public static string format(EvexMapKind src)
            => EvexMap.Format(src);

        public static string format(LegacyMapKind src)
            => LegacyMap.Format(src);

        public static string format(CellDataKind src)
            => CellDataKinds.Format(src);

        public static string format(RuleTableKind src)
            => RuleTableKinds.Format(src);

        public static string format(GroupName src)
            => EncodingGroups.Format(src);

        public static string format(FieldKind src)
            => FieldKinds.Format(src);

        public static string format(FieldKind src, bool name)
            => FieldKinds.Format(src,name);

        public static string format(RuleMacroKind src)
            => MacroKinds.Format(src);

        public static string format(AttributeKind src)
            => AttribKinds.Format(src);

        public static string format(BCast8Kind src)
            => BCast8.Format(src);

        public static string format(BCast16Kind src)
            => BCast16.Format(src);

        public static string format(RuleOpKind src)
            => RuleOpKinds.Format(src);

        public static string format(BCast32Kind src)
            => BCast32.Format(src);

        public static string format(BCast64Kind src)
            => BCast64.Format(src);

        public static string format(VisibilityKind src)
            => VisKind.Format(src);

        public static string format(NontermKind src)
            => NontermKinds.Format(src);

        public static string format(ROUNDC src)
            => RoundingKinds.Format(src);

        public static string format(XedRegId src)
            => XedRegs[src].Expr.Text;

        public static string format(OperandAction src)
            => OpActions[src].Expr.Text;

        public static string format(ChipCode src)
            => ChipCodes.Format(src);

        public static string format(XopMapKind src)
            => src == 0 ? EmptyString : src.ToString();

        public static string format(IClass src)
            => Classes.Format(src);

        public static string format(ConstraintKind src)
            => ConstraintKinds[src].Expr.Text;

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
            => ElementTypes.Format(src);

        public static string format(OpVisibility src)
            => OpVis[src].Expr.Text;

        public static string format(OpCodeKind src)
            => format(ocindex(src));

        public static string format(ImmFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}{1}[i/{2}]", "UIMM", src.Index, src.Width);

        public static string format(DispFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}[{1}/{2}]", "DISP", src.Kind, src.Width);

        public static string format(in InstDefPart src)
        {
            var dst = EmptyString;
            var kind = src.PartKind;
            switch(kind)
            {
                case DefSegKind.HexLiteral:
                    dst = format(src.AsHexLit());
                break;
                case DefSegKind.IntLiteral:
                    dst = src.AsIntLit().ToString();
                break;
                case DefSegKind.Bitfield:
                    dst = format(src.AsBfSeg());
                break;
                case DefSegKind.BitLiteral:
                    dst = format5(src.AsB5());
                break;
                case DefSegKind.Nonterm:
                    dst = src.AsNonterminal().Format();
                break;
                case DefSegKind.FieldLiteral:
                    dst = format(src.AsFieldLit());
                break;
                case DefSegKind.FieldAssign:
                    dst = format(src.AsAssign());
                break;
                case DefSegKind.Constraint:
                    dst = format(src.AsConstraint());
                break;
                default:
                    Errors.Throw("Unknown Part");
                    break;
            }

            return dst;
        }

        public static string format(RuleCellKind src)
        {
            var dst = EmptyString;

            if(src.Test(RuleCellKind.Assignment))
                dst = "assign";
            else if(src.Test(RuleCellKind.CmpNeq))
                dst = "cmpneq";
            else if(src.Test(RuleCellKind.CmpEq))
                dst = "cmpeq";

            if(src.Test(RuleCellKind.Nonterminal))
            {
                if(text.empty(dst))
                    dst = "nt";
                else
                    dst += "/nt";
            }

            if(src.Test(RuleCellKind.Literal))
            {
                if(text.empty(dst))
                    dst = "literal";
                else
                    dst += "/literal";
            }

            if(src.Test(RuleCellKind.BfSeg))
            {
                if(text.empty(dst))
                    dst = "bfseg";
                else
                    dst += "/bfseg";
            }

            if(src.Test(RuleCellKind.Bits))
            {
                if(text.empty(dst))
                    dst = "bits";
                else
                    dst += "/bits";
            }

            if(src.Test(RuleCellKind.Hex))
            {
                if(text.empty(dst))
                    dst = "hex";
                else
                    dst += "/hex";
            }

            if(src.Test(RuleCellKind.Int))
            {
                if(text.empty(dst))
                    dst = "int";
                else
                    dst += "/int";
            }

            if(src.Test(RuleCellKind.FieldValue))
            {
                if(text.empty(dst))
                    dst = "field";
                else
                    dst += "/field";
            }

            if(text.empty(dst))
                dst = RP.Error;

            return dst;
        }

        public static string format(RuleCall src)
        {
            if(src.IsEmpty)
                return RP.Error;
            else
            {
                if(src.Field == 0)
                    return string.Format("{0}()", src.Target.Format());
                else
                    return string.Format("{0}{1}{2}()", format(src.Field), format(src.Operator), src.Target.Format());
            }
        }

        public static string format(BitfieldSeg src)
            => string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

        public static string format(BitfieldSpec src)
            => src.Pattern.Format();

        public static string format(in MacroSpec src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Expansions.Count; i++)
            {
                ref readonly var x = ref src.Expansions[i];
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(x.Format());
            }
            return dst.Emit();
        }

        public static string format(in RuleCell src)
        {
            var input = src.Data;
            var result = input;
            if(src.Premise)
            {
                if(XedParsers.Assignment(input, out var left, out var right))
                    result = string.Format("{0}{1}{2}",left,"==",right);
            }
            return input;
        }

        public static string format(in StatementSpec src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Premise.Count;  i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(src.Premise[i].Format());
            }

            dst.Append(" => ");

            for(var i=0; i<src.Consequent.Count;  i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(src.Consequent[i].Format());
            }
            return dst.Emit();
        }

        public static string format(in RuleTable src)
        {
            var dst = text.buffer();
            dst.AppendLine(string.Format("{0}()", src.Sig.Name));
            var expressions = src.Body.View;
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, format(skip(expressions, i)));
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        static string format5(uint5 src)
        {
            var storage = 0ul;
            var dst = recover<AsciSymbol>(bytes(storage));
            var i=0;
            var j=(byte)(uint5.Width - 1);
            seek(dst,i++) = Chars.D0;
            seek(dst,i++) = Chars.b;
            seek(dst,i++) = src[j--].ToChar();
            seek(dst,i++) = src[j--].ToChar();
            seek(dst,i++) = src[j--].ToChar();
            seek(dst,i++) = src[j--].ToChar();
            seek(dst,i++) = Chars.Underscore;
            seek(dst,i++) = src[j].ToChar();
            return new asci8(storage);
        }

        static string format(Hex8 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(FieldAssign src)
        {
            if(src.IsEmpty)
                return EmptyString;
            else if(src.Field == 0)
                return src.Value.ToString();
            else
                return string.Format("{0}={1}", format(src.Field), format(src.Value));
        }

        public static string format(FieldCmp src)
        {
            if(src.IsEmpty)
                return EmptyString;

            return src.IsEmpty ? EmptyString
                : string.Format("{0}{1}{2}",
                    format(src.Field),
                    format(src.Operator),
                    format(src.Value)
                    );
        }

        static string format<E>(EnumRender<E> render, E src, FormatCode fc)
            where E : unmanaged, Enum
        {
            var dst = EmptyString;
            switch(fc)
            {
                case FormatCode.SInt:
                    dst = ((int)bw32(src)).ToString();
                break;
                case FormatCode.Hex:
                    dst = bw32(src).FormatHex();
                break;
                case FormatCode.UInt:
                    dst = bw32(src).ToString();
                break;
                case FormatCode.Name:
                    dst = render.Format(src, true);
                break;
                default:
                    dst = render.Format(src);
                break;
            }
            return dst;
        }

        static string nsize<T>(T src)
            => ((NativeSize)((NativeSizeCode)u8(src))).Format();
    }
}