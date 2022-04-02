//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
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

    using R = XedRules;
    using OC = XedRules.OpAttribClass;

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

        static EnumRender<BaseMapKind> LegacyMap = new();

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

        static EnumRender<ExtensionKind> ExtensionKinds = new();

        static EnumRender<DispExprKind> DispKinds = new();

        static EnumRender<NontermKind> NontermKinds = new();

        static EnumRender<ROUNDC> RoundingKinds = new();

        static EnumRender<SMode> SModes = new();

        static EnumRender<MASK> MaskCodes = new();

        static EnumRender<CellDataKind> CellDataKinds = new();

        static EnumRender<ChipCode> ChipCodes = new();

        static EnumRender<RuleOperator> RuleOps = new();

        static EnumRender<OpAction> OpActions = new();

        static EnumRender<OpWidthCode> OpWidthKinds = new();

        static EnumRender<ElementKind> ElementTypes = new();

        static EnumRender<OpNameKind> OpNames = new();

        static EnumRender<OpVisibility> OpVis = new();

        static EnumRender<IClass> Classes = new();

        static EnumRender<VexLengthKind> VexLengthKinds = new();

        static EnumRender<OSZ> OszKinds = new();

        static EnumRender<ASZ> AszKinds = new();

        static EnumRender<CategoryKind> CategoryKinds = new();

        static EnumRender<IsaKind> IsaKinds = new();

        static EnumRender<OpType> OpTypes = new();

        static EnumRender<BfSegKind> BfSegKinds = new();

        static EnumRender<BfSpecKind> BfSpecKinds = new();

        static Index<BroadcastDef> BroadcastDefs = IntelXed.BcastDefs();

        static EnumRender<XedRegId> XedRegs = new();

        public static string format(Hex8 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex16 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex32 src)
            => src.Format(prespec:true, uppercase:true);

        public static string format(Hex64 src)
            => src.Format(prespec:true, uppercase:true);

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

        public static string format(FlagEffectKind src)
            => FlagEffects.Format(src);

        public static string format(XedRegFlag src)
            => RegFlags.Format(src);

        public static string format(IsaKind src)
            => src == 0 ? EmptyString : IsaKinds.Format(src);

        public static string format(ExtensionKind src)
            => src == 0 ? EmptyString : ExtensionKinds.Format(src);

        public static string format(CategoryKind src)
            => src == 0 ? EmptyString : CategoryKinds.Format(src);

        public static string format(OpWidth src)
            => src.Code != 0 ?  format(src.Code) : (src.Bits != 0 ? src.Bits.ToString() : src.Gpr.Format());

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

        public static string format(ASZ src)
            => AszKinds.Format(src);

        public static string format(OSZ src)
            => OszKinds.Format(src);

        public static string format(BfSegKind src)
            => BfSegKinds.Format(src);

        public static string format(BfSpecKind src)
            => BfSpecKinds.Format(src);

        public static string format(R.FieldValue src)
            => XedFields.format(src);

        public static string format(in FieldExpr src)
            => src.IsEmpty
                ? EmptyString : src.Field == 0 ? format(src.Value)
                : string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.Value));

        public static string format(in RuleTableCell src)
            => src.IsEmpty ? EmptyString : src.Criterion.Format();

        public static string format(AsmOcValue src)
            => AsmOcValue.format(src);

        public static string format(EvexMapKind src)
            => EvexMap.Format(src);

        public static string format(BaseMapKind src)
            => LegacyMap.Format(src);

        public static string format(CellDataKind src)
            => CellDataKinds.Format(src);

        public static string format(RuleTableKind src)
            => RuleTableKinds.Format(src);

        public static string format(FieldKind src)
            => src == 0 ? EmptyString : FieldKinds.Format(src);

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

        public static string format(Visibility src)
        {
            if(src.V0 != 0)
                return format(src.V0);
            else if(src.V1 != 0)
                return format(src.V1);
            else
                return EmptyString;
        }

        public static string format(ROUNDC src)
            => RoundingKinds.Format(src);

        public static string format(XedRegId src)
            => src == 0 ? EmptyString : XedRegs.Format(src);

        public static string format(OpAction src)
            => OpActions.Format(src);

        public static string format(ChipCode src)
            => ChipCodes.Format(src);

        public static string format(XopMapKind src)
            => src == 0 ? EmptyString : src.ToString();

        public static string format(IClass src)
            => Classes.Format(src);

        public static string format(OpModKind src)
            => OpModKinds.Format(src);

        public static string format(VexMapKind src)
            => VexMap.Format(src);

        public static string format(OpWidthCode src)
            => src == 0 ? EmptyString : OpWidthKinds.Format(src);

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

        public static string format(OpType src)
            => OpTypes.Format(src);

        static void render(ReadOnlySpan<RuleCriterion> src, ITextBuffer dst)
        {
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(counter != 0)
                    dst.Append(" && ");

                dst.Append(c.Format());
                counter++;
            }
        }

        public static string format(EoszKind src)
        {
            var dst = EmptyString;
            if(src != 0)
            {
                if(src.Test(EoszKind.W8))
                    dst = "8";

                if(src.Test(EoszKind.W16))
                {
                    if(text.empty(dst))
                        dst = "16";
                    else
                        dst += "16";
                }

                if(src.Test(EoszKind.W32))
                {
                    if(text.empty(dst))
                        dst = "32";
                    else
                        dst += "32";
                }

                if(src.Test(EoszKind.W64))
                {
                    if(text.empty(dst))
                        dst = "64";
                    else
                        dst += "64";

                }
            }
            return dst;
        }

        public static string format(Index<XedFlagEffect> src, bool embrace = true, char sep = Chars.Comma)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            if(embrace)
                dst.Append(Chars.LBrace);
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(sep);

                dst.Append(format(src[i]));
            }
            if(embrace)
                dst.Append(Chars.RBrace);

            return dst.Emit();
        }

        public static string format(in XedFlagEffect src)
            => string.Format("{0}-{1}", format(src.Flag), format(src.Effect));

        public static string name(Nonterminal src)
            => NontermKinds.Format(src.Kind);

        public static string format(Nonterminal src)
        {
            if(src.IsNonEmpty)
                return string.Format("{0}()", name(src));
            else
                return EmptyString;
        }

        public static string format(in OpAttribs src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Colon);

                dst.Append(src[i].Format());
            }

            return dst.Emit();
        }

        public static string format(in PatternOp src)
        {
            var dst = text.buffer();
            dst.Append(XedRender.format(src.Name));
            if(src.Attribs.IsNonEmpty)
                dst.Append(Chars.Colon);
            dst.Append(format(src.Attribs));
            return dst.Emit();
        }

        public static string format(OpAttrib src)
        {
            var dst = EmptyString;
            switch(src.Class)
            {
                case OC.None:
                    dst = EmptyString;
                break;

                case OC.Action:
                    dst = format(src.ToAction());
                break;
                case OC.Width:
                    dst = format(src.ToWidthCode());
                break;

                case OC.ElementType:
                    dst = src.ToElementType().Format();
                break;

                case OC.Modifier:
                    dst = src.ToModifier().Format();
                break;

                case OC.Scale:
                    dst = src.ToScale().Format();
                break;

                case OC.Nonterminal:
                    dst = src.ToNonTerm().Format();
                break;

                case OC.Visibility:
                    dst = src.ToVisibility().Format();
                break;

                case OC.RegLiteral:
                    dst = format(src.ToRegLiteral());
                break;

                default:
                    Errors.Throw(string.Format("Unhandled class:{0}", src.Class));
                break;
            }
            return dst;
        }

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
            render(src.Storage, dst);
            return dst.Emit();
        }

        public static void render(ReadOnlySpan<InstDefField> src, ITextBuffer dst)
        {
            for(var i=0; i<src.Length; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                dst.Append(format(skip(src,i)));
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
            if(src.IsEmpty)
                return EmptyString;

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

        public static string format(OpNameKind src)
            => src == 0 ? EmptyString : OpNames.Format(src);

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

        public static string format(PointerWidth src)
            => src.Keyword.Format();

        public static string format(ElementType src)
            => src.IsEmpty ? EmptyString : ElementTypes.Format(src.Kind);

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
            var @class = src.FieldClass;
            switch(@class)
            {
                case DefFieldClass.HexLiteral:
                    dst = format(src.AsHexLit());
                break;
                case DefFieldClass.IntLiteral:
                    dst = src.AsIntLit().ToString();
                break;
                case DefFieldClass.Bitfield:
                    dst = format(src.AsBitfield());
                break;
                case DefFieldClass.BitLiteral:
                    dst = format5(src.AsBitLit());
                break;
                case DefFieldClass.Nonterm:
                    dst = format(src.AsNonterminal());
                break;
                case DefFieldClass.FieldExpr:
                    dst = format(src.AsFieldExpr());
                break;
                default:
                    Errors.Throw(string.Format("Unknown Part:{0} | {1}", @class, bytes(src).FormatHex()));
                    break;
            }

            return dst;
        }

        public static string format(RuleCellKind src)
        {
            var dst = EmptyString;
            dst = format(XedRules.datakind(src));
            return dst;
        }

        public static string format(BfSeg src)
            => src.IsEmpty ? EmptyString : string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

        public static string format(BfSpec src)
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
            dst.AppendLine(string.Format("{0}()", src.Name.ShortName));
            var expressions = src.Body.View;
            var count = expressions.Length;
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<count; i++)
                dst.IndentLine(4, format(skip(expressions, i)));
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        public static string format(in XedOpCode src)
            => string.Format("{0}:{1}", src.Kind, AsmOcValue.format(src.Value));

        public static string format(InstAttribs src, bool embrace = true, char sep = Chars.Comma)
        {
            if(src.IsEmpty)
                return EmptyString;
            var dst = text.buffer();
            if(embrace)
                dst.Append(Chars.LBrace);
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.Append(format(src[i]));
            }
            if(embrace)
                dst.Append(Chars.RBrace);
            return dst.Emit();
        }

        public static string format(in FieldSet src)
        {
            var dst = text.buffer();
            Span<FieldKind> kinds = stackalloc FieldKind[FieldSet.Capacity];
            var count = src.Members(kinds);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Comma);
                dst.Append(format(skip(kinds,i)));
            }
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

        public static string format(FieldAssign src)
            => format(src.Expression());

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
            if(width.CellType.IsNumber)
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