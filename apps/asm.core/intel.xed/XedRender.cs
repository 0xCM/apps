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
    using static XedFields;
    using static XedDisasm;
    using static core;

    using OC = XedRules.OpAttribClass;

    public partial class XedRender
    {
        static EnumRender<Asm.FlagEffectKind> FlagEffects = new();

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

        static EnumRender<DispSpec> DispSpecs = new();

        static EnumRender<NontermKind> NontermKinds = new();

        static EnumRender<ROUNDC> RoundingKinds = new();

        static EnumRender<SMode> SModes = new();

        static EnumRender<MASK> MaskCodes = new();

        static EnumRender<ChipCode> ChipCodes = new();

        static EnumRender<OperatorKind> RuleOps = new();

        static EnumRender<OpAction> OpActions = new();

        static EnumRender<OpWidthCode> OpWidthKinds = new();

        static EnumRender<ElementKind> ElementTypes = new();

        static EnumRender<XedModels.RepPrefix> RepPrexixKinds = new();

        static EnumRender<OpNameKind> OpNames = new();

        static EnumRender<OpVisibility> OpVis = new();

        static EnumRender<IClass> Classes = new();

        static EnumRender<VexLengthKind> VexLengthKinds = new();

        static EnumRender<OSZ> OszKinds = new();

        static EnumRender<ASZ> AszKinds = new();

        static EnumRender<CategoryKind> CategoryKinds = new();

        static EnumRender<IsaKind> IsaKinds = new();

        static EnumRender<OpType> OpTypes = new();

        static EnumRender<HintKind> HintKinds = new();

        static EnumRender<ImmSpec> ImmSpecs = new();

        static EnumRender<InstFieldClass> InstFieldClasses = new();

        static Index<Asm.BroadcastDef> BroadcastDefs = IntelXed.BcastDefs();

        static readonly EnumRender<ModIndicator> ModIndicators = new();

        static EnumRender<XedRegId> XedRegs = new();

        public static string format(Hex4 src)
            => src.Format(prespec:true, uppercase:true);

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
            => "0b" + src.Format();

        public static string format(uint8b src)
            => "0b" + src.Format();

        public static string format(byte src)
            => src.ToString();

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
            => src.Code != 0 ?  format(src.Code) : (src.Bits != 0 ? src.Bits.ToString() : EmptyString);

        public static string format(OpCodeIndex src, FormatCode fc = FormatCode.Expr)
            => format(OcKindIndex, src, fc);

        public static string format(EASZ src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize(src) : format(EaszKinds,src,fc);

        public static string format(EOSZ src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize(src) : format(EoszKinds,src,fc);

        public static string format(ImmSpec src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? (((byte)src)*8).ToString() : format(ImmSpecs,src,fc);

        public static string format(ModeKind src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize((byte)src + 1) : format(ModeKinds,src,fc);

        public static string format(SMode src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? nsize((byte)src + 1) : format(SModes,src,fc);

        public static string format(VexClass src, FormatCode fc = FormatCode.Expr)
            => format(VexClasses, src, fc);

        public static string format(HintKind src, FormatCode fc = FormatCode.Expr)
            => format(HintKinds, src, fc);

        public static string format(VexKind src, FormatCode fc = FormatCode.Expr)
            => format(VexKinds, src, fc);

        public static string format(MASK src, FormatCode fc = FormatCode.Expr)
            => format(MaskCodes, src, fc);

        public static string format(XedModels.RepPrefix src, FormatCode fc = FormatCode.Expr)
            => format(RepPrexixKinds, src, fc);

        public static string format(VexLengthKind src, FormatCode fc = FormatCode.Expr)
            => fc == FormatCode.BitWidth ? XedPatterns.bitwidth(src).ToString() : format(VexLengthKinds,src,fc);

        public static string format(InstFieldClass src)
            => InstFieldClasses.Format(src);

        public static string format(ASZ src)
            => AszKinds.Format(src);

        public static string format(OSZ src)
            => OszKinds.Format(src);

        public static string format(ModIndicator src)
            => ModIndicators.Format(src);

        public static string format(CellValue src)
            => CellRender.format(src);

        public static string format(RuleKeyword src)
            => src.ToAsci().Format();

        public static string format(in CellExpr src)
            => src.IsEmpty
                ? EmptyString
                : src.Field == 0
                ? format(src.Value)
                : string.Format("{0}{1}{2}", format(src.Field), format(src.Operator), format(src.Value));

        public static string format(AsmOcValue src)
            => AsmOcValue.format(src);

        public static string format(EvexMapKind src)
            => EvexMap.Format(src);

        public static string format(BaseMapKind src)
            => LegacyMap.Format(src);


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
            => XedRegs.Format(src);

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

        public static string format(OpType src)
            => OpTypes.Format(src);

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

        public static string format(NontermKind src)
            => NontermKinds.Format(src);

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

        public static void render(ReadOnlySpan<InstField> src, ITextBuffer dst)
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

        public static string format(OperatorKind src)
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

        public static string format(in TableSpec src)
        {
            var dst = text.buffer();
            dst.AppendLine(string.Format("{0}()", src.Sig.ShortName));
            dst.AppendLine(Chars.LBrace);
            for(var i=0; i<src.Rows.Count; i++)
                dst.IndentLine(4, src.Rows[i]);
            dst.AppendLine(Chars.RBrace);
            return dst.Emit();
        }

        public static string format(PointerWidth src)
            => src.Keyword.Format();

        public static string format(ElementType src)
            => src.IsEmpty ? EmptyString : ElementTypes.Format(src.Kind);

        public static string format(OpVisibility src)
            => OpVis.Format(src);

        public static string format(OpCodeKind src)
            => format(XedOpCodes.ocindex(src));

        public static string format(ImmSeg src)
            => src.IsEmpty ? EmptyString : string.Format("{0}[{1}]", "UIMM", src.Index, format(src.Spec));

        public static string format(ImmSpec src)
            => ImmSpecs.Format(src);

        public static string format(DispSpec src)
            => DispSpecs.Format(src);

        public static string format(DispSeg src)
            => src.IsEmpty ? EmptyString : string.Format("{0}[{1}]", "DISP", format(src.Spec));

        public static string format(in InstField src)
        {
            var dst = EmptyString;
            var @class = src.DataKind;
            switch(@class)
            {
                case InstFieldKind.HexLiteral:
                    dst = format(src.AsHexLit());
                break;
                case InstFieldKind.IntLiteral:
                    dst = src.AsIntLit().ToString();
                break;
                case InstFieldKind.Seg:
                    dst = src.AsSegField().Format();
                break;
                case InstFieldKind.BitLiteral:
                    dst = format5(src.AsBitLit());
                break;
                case InstFieldKind.Nonterm:
                    dst = format(src.AsNonterminal());
                break;
                case InstFieldKind.Expr:
                    dst = format(src.AsFieldExpr());
                break;
                default:
                    Errors.Throw(string.Format("Unknown Part:{0} | {1}", @class, bytes(src).FormatHex()));
                    break;
            }

            return dst;
        }

        public static string format(BfSeg src)
            => src.IsEmpty ? EmptyString : string.Format(src.IsLiteral ? "{0}[0b{1}]" : "{0}[{1}]", XedRender.format(src.Field), src.Pattern);

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


        public static string format(in RowSpec src)
        {
            var dst = text.buffer();

            if(src.Antecedant.Count == 0)
                dst.Append(XedNames.Null);

            for(var i=0; i<src.Antecedant.Count; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);
                dst.Append(src.Antecedant[i].Data);
            }

            if(src.Consequent.Count != 0)
            {
                dst.AppendFormat(" {0} ", XedNames.Implication);

                for(var i=0; i<src.Consequent.Count; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);
                    dst.Append(src.Consequent[i].Data);
                }
            }
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

        public static string format(in FunctionSet src, char sep = Chars.Comma)
        {
            var dst = text.buffer();
            var counter = 0u;
            for(var i=0; i<FunctionSet.MaxCount; i++)
            {
                var kind = (NontermKind)i;
                if(src.Contains(kind))
                {
                    if(counter != 0)
                        dst.Append(sep);
                    dst.Append(XedRender.format(kind));
                    counter++;
                }
            }
            return dst.Emit();
        }

        public static string format(in FieldSet src, char sep = Chars.Comma)
        {
            var dst = text.buffer();
            Span<FieldKind> kinds = stackalloc FieldKind[FieldSet.Capacity];
            var count = src.Members(kinds);
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(sep);
                dst.Append(XedRender.format(skip(kinds,i)));
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

        public static string format(in EncodingExtract src)
        {
            const string RP0 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12}";
            const string RP1 = "{0,-8} | {1,-5} | {2,-5} | {3,-12} | {4,-12} | {5,-5}";
            var pattern = src.Offsets.HasImm1 ? RP1 : RP0;
            var header = string.Format(pattern, nameof(src.OpCode), nameof(src.ModRm), nameof(src.Sib), nameof(src.Imm), nameof(src.Disp), nameof(src.Imm1));
            var content = string.Format(pattern,
                XedRender.format(src.OpCode),
                src.Offsets.HasModRm ? src.ModRm.Format() : EmptyString,
                src.Offsets.HasSib ? src.Sib.Format() : EmptyString,
                src.Offsets.HasImm0 ? src.Imm.Format() : EmptyString,
                src.Offsets.HasDisp ? src.Disp.Format() : EmptyString,
                src.Offsets.HasImm1 ? src.Imm1.Format() : EmptyString
                );
            return string.Format("{0}{1}{2}",header, RP.Eol, content);
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