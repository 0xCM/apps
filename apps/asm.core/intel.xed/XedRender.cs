//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static XedPatterns;
    using static XedFields;
    using static XedDisasm;
    using static core;

    using PW = XedModels.PointerWidthKind;
    using R = XedRules;
    using OC = XedRules.OpClass;

    public partial class XedRender
    {
        static EnumRender<FlagEffectKind> FlagEffects = new();

        static EnumRender<XedRegFlag> RegFlags = new();

        static EnumRender<BCast8Kind> BCast8 = new();

        static EnumRender<BCast16Kind> BCast16 = new();

        static EnumRender<BCast32Kind> BCast32 = new();

        static EnumRender<BCast64Kind> BCast64 = new();

        static EnumRender<ModeKind> ModeKinds = new();

        static EnumRender<VisibilityKind> VisKind = new();

        static EnumRender<VexClass> VexClasses = new();

        static EnumRender<VexKind> VexKinds = new();

        static EnumRender<VexMapKind> VexMap = new();

        static EnumRender<LegacyMapKind> LegacyMap = new();

        static EnumRender<EvexMapKind> EvexMap = new();

        static EnumRender<AttributeKind> AttribKinds = new();

        static EnumRender<OpCodeIndex> OcKindIndex = new();

        static EnumRender<OpKind> RuleOpKinds = new();

        static EnumRender<RuleMacroKind> MacroKinds = new();

        static EnumRender<OpModKind> OpModKinds = new();

        static EnumRender<FieldKind> FieldKinds = new();

        static EnumRender<RuleTableKind> RuleTableKinds = new();

        static EnumRender<EASZ> EaszKinds = new();

        static EnumRender<EOSZ> EoszKinds = new();

        static EnumRender<DispExprKind> DispKinds = new();

        static EnumRender<NontermKind> NontermKinds = new();

        static EnumRender<GroupName> EncodingGroups = new();

        static EnumRender<ROUNDC> RoundingKinds = new();

        static EnumRender<SMode> SModes = new();

        static EnumRender<MASK> MaskCodes = new();

        static EnumRender<CellDataKind> CellDataKinds = new();

        static EnumRender<ChipCode> ChipCodes = new();

        static EnumRender<RuleOperator> RuleOps = new();

        static EnumRender<ConstraintKind> ConstraintKinds = new();

        static EnumRender<OpAction> OpActions = new();

        static EnumRender<OpWidthCode> OpWidthKinds = new();

        static EnumRender<ElementKind> ElementTypes = new();

        static EnumRender<OpName> OpNames = new();

        static EnumRender<OpVisibility> OpVis = new();

        static EnumRender<IClass> Classes = new();

        static EnumRender<VexLengthKind> VexLengthKinds = new();

        static EnumRender<OSZ> OszKinds = new();

        static Index<AsmBroadcastDef> BroadcastDefs = IntelXed.BcastDefs();

        static Symbols<XedRegId> XedRegs = Symbols.index<XedRegId>();


        public static string format(in RuleStatement src)
        {
            var sep = " <=> ";
            var dst = text.buffer();
            render(src.Premise, dst);
            var a = dst.Emit();

            render(src.Consequent, dst);
            var b = dst.Emit();

            return string.Format("{0}{1}{2}", a, sep, b);
        }

        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(counter != 0)
                    dst.Append(" && ");

                dst.Append(format(c));
                counter++;
            }
        }

        public static string format(EoszKind src)
            => src.Format();

        public static string format(FlagEffectKind src)
            => FlagEffects.Format(src);

        public static string format(XedRegFlag src)
            => RegFlags.Format(src);

        public static string format(Index<XedFlagEffect> src)
            => src.IsNonEmpty ? src.Delimit(fence:RenderFence.Embraced).Format() : EmptyString;

        public static string format(in XedFlagEffect src)
            => string.Format("{0}-{1}", format(src.Flag), format(src.Effect));

        public static string format(in RuleCriterion src)
        {
            if(src.IsCall)
                return format(src.AsCall());
            else if(src.IsNonterminal)
            {
                var fmt = src.AsNonterminal().Format();
                if(src.Field != 0 && src.Operator != 0)
                    return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), fmt);
                else
                    return fmt;
            }
            else if(src.IsLiteral)
                return src.AsLiteral().Format();
            else if(src.IsAssignment)
                return format(src.AsAssignment());
            else if(src.IsComparison)
                return format(src.AsCmp());
            else if(src.IsBfSeg)
                return format(src.AsBfSeg());
            else if(src.IsBfSpec)
                return format(src.AsBfSpec());
            else
                return string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.AsValue()));
        }

        public static string format(OpWidth src)
            => src.IsNonEmpty ? format(src.Code) : EmptyString;

        public static string format(OpAttrib src)
        {
            var dst = EmptyString;
            switch(src.Class)
            {
                case OC.None:
                break;

                case OC.Action:
                    dst = format(src.AsAction());
                break;
                case OC.OpWidth:
                    dst = format(src.AsOpWidth());
                break;

                case OC.PtrWidth:
                    dst = format(src.AsPtrWidth());
                break;

                case OC.ElementType:
                    dst = format(src.AsElementType());
                break;

                case OC.Modifier:
                    dst = format(src.AsModifier());
                break;

                case OC.Nonterminal:
                    dst = format(src.AsNonTerm());
                break;

                case OC.Visibility:
                    dst = src.AsVisibility().Format();
                break;

                case OC.RegLiteral:
                    dst = format(src.AsRegLiteral());
                break;

                case OC.Scale:
                    dst = src.AsScale().Format();
                break;

                default:
                    Errors.Throw(string.Format("Unhandled class:{0}", src.Class));
                break;
            }
            return dst;
        }

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

        public static string format(VexLengthKind src)
            => VexLengthKinds.Format(src);

        public static string format(OSZ src)
            => OszKinds.Format(src);

        public static string format(R.FieldValue src)
            => XedFields.format(src);

        public static string format(FieldConstraint src)
            =>  XedFields.format(src);

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
            for(var i=0; i<src.FieldCount; i++)
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

        public static string format(OpName src)
            => OpNames.Format(src);

        public static string format(RuleOperator src)
            => RuleOps.Format(src);

        [MethodImpl(Inline)]
        public static string format(BCastKind src)
        {
            if(src == 0)
                return EmptyString;

            var index = (byte)src;
            if(index < BroadcastDefs.Count)
                return BroadcastDefs[index].Symbol.Format();
            else
                return RP.Error;
        }

        public static string format(OpModKind src)
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

        public static string format(OpKind src)
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

        public static string format(OpAction src)
            => OpActions.Format(src);

        public static string format(ChipCode src)
            => ChipCodes.Format(src);

        public static string format(XopMapKind src)
            => src == 0 ? EmptyString : src.ToString();

        public static string format(IClass src)
            => Classes.Format(src);

        public static string format(ConstraintKind src)
            => ConstraintKinds.Format(src);

        public static string format(OpWidthCode src)
            => OpWidthKinds.Format(src);

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
            => OpVis.Format(src);

        public static string format(OpCodeKind src)
            => format(XedPatterns.ocindex(src));

        public static string format(ImmFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}{1}[i/{2}]", "UIMM", src.Index, src.Width);

        public static string format(DispFieldSpec src)
            => src.Width == 0 ? EmptyString : string.Format("{0}[{1}/{2}]", "DISP", src.Kind, src.Width);

        public static string format(in InstDefField src)
        {
            var dst = EmptyString;
            var kind = src.FieldClass;
            switch(kind)
            {
                case DefFieldClass.HexLiteral:
                    dst = format(src.AsHexLit());
                break;
                case DefFieldClass.IntLiteral:
                    dst = src.AsIntLit().ToString();
                break;
                case DefFieldClass.Bitfield:
                    dst = format(src.AsBfSeg());
                break;
                case DefFieldClass.BitLiteral:
                    dst = format5(src.AsBitLit());
                break;
                case DefFieldClass.Nonterm:
                    dst = src.AsNonterminal().Format();
                break;
                case DefFieldClass.FieldLiteral:
                    dst = format(src.AsFieldLit());
                break;
                case DefFieldClass.FieldAssign:
                    dst = format(src.AsAssignment());
                break;
                case DefFieldClass.Constraint:
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
            => src.IsEmpty ? EmptyString : string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

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
            => src.Data;

        public static string format(in StatementSpec src)
        {
            var dst = text.buffer();

            if(src.Premise.Count == 0)
                dst.Append(XedNames.Null);

            for(var i=0; i<src.Premise.Count; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);
                dst.Append(format(src.Premise[i]));
            }

            if(src.Consequent.Count != 0)
            {
                dst.AppendFormat(" {0} ", XedNames.Implication);

                for(var i=0; i<src.Consequent.Count; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);
                    dst.Append(format(src.Consequent[i]));
                }
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

        public static string format(in XedOpCode src)
            => string.Format("{0} {1}", XedPatterns.symbol(src.Kind), format(src.Value));

        public static string format(uint1 src)
            => "0b" + src.Format();

        public static string format(uint2 src)
            => "0b" + src.Format();

        public static string format(uint3 src)
            => "0b" +  src.Format();

        public static string format(uint4 src)
            => "0b" + src.Format();

        public static string format(uint5 src)
            => "0b" + src.Format();

        public static string format(uint6 src)
            => "0b" + src.Format();

        public static string format(uint7 src)
            =>  "0b" + src.Format();

        public static string format(uint8b src)
            =>  "0b" + src.Format();

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

        public static string format(Hex8 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex16 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex32 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex64 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(FieldAssign src)
        {
            if(src.IsEmpty)
                return EmptyString;
            else if(src.Field == 0)
                return src.Value.ToString();
            else
                return string.Format("{0}{1}{2}", format(src.Field), XedNames.Assign, format(src.Value));
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

        public static string format(in DisasmOpDetail src)
        {
            const string OpSepSlot = "/{0}";
            var dst = text.buffer();
            dst.AppendFormat("{0,-6} {1,-4}", src.Index, XedRender.format(src.OpName));
            var kind = opkind(src.OpName);
            ref readonly var opinfo = ref src.OpInfo;
            switch(kind)
            {
                case OpKind.Reg:
                case OpKind.Base:
                case OpKind.Index:
                    if(opinfo.Selector.IsNonEmpty)
                    {
                        dst.AppendFormat(" {0}", opinfo.Selector);
                        dst.AppendFormat(OpSepSlot, XedRender.format(src.Action));
                    }
                break;
                default:
                    dst.AppendFormat(" {0}", XedRender.format(src.Action));
                break;
            }

            ref readonly var width = ref src.OpWidth;
            dst.AppendFormat(OpSepSlot, XedRender.format(width.Code));
            if(width.CellType.IsNonEmpty && !width.CellType.IsInt)
                dst.AppendFormat(OpSepSlot, src.OpWidth.CellType);
            if(!opinfo.Visiblity.IsExplicit)
                dst.AppendFormat(OpSepSlot, opinfo.Visiblity);
            if(opinfo.OpType != 0)
                dst.AppendFormat(OpSepSlot, opinfo.OpType);

            return dst.Emit();
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