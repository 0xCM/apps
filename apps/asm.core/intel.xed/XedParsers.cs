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
    using static XedRules.SyntaxLiterals;
    using static core;

    using R = XedRules;
    using RF = XedRules.RuleFormKind;

    public partial class XedParsers
    {
        static readonly EnumParser<OpWidthCode> OpWidthParser = new();

        static readonly EnumParser<OpAction> OpActions = new();

        static readonly EnumParser<OpType> OpTypes = new();

        static readonly EnumParser<PointerWidthKind> PointerWidths = new();

        static readonly EnumParser<NontermKind> Nonterminals = new();

        static readonly EnumParser<XedRegId> Regs = new();

        static readonly EnumParser<ElementKind> ElementKinds = new();

        static readonly EnumParser<OpVisibility> OpVisKinds = new();

        static readonly EnumParser<VisibilityKind> VisKinds = new();

        static readonly EnumParser<OpModKind> OpModKinds = new();

        static readonly EnumParser<FieldKind> FieldKinds = new();

        static readonly EnumParser<FpuRegId> FpuRegs = new();

        static readonly EnumParser<IClass> Classes = new();

        static readonly EnumParser<IFormType> Forms = new();

        static readonly EnumParser<ExtensionKind> ExtensionKinds = new();

        static readonly EnumParser<FlagEffectKind> FlagActionKinds = new();

        static readonly EnumParser<XedRegFlag> RegFlags = new();

        static readonly EnumParser<IsaKind> IsaKinds = new();

        static readonly EnumParser<CategoryKind> CategoryKinds = new();

        static readonly EnumParser<OpNameKind> RuleOpNames = new();

        static readonly EnumParser<RuleMacroKind> MacroKinds = new();

        static readonly EnumParser<VexClass> VexClasses = new();

        static readonly EnumParser<VexKind> VexKinds = new();

        static readonly EnumParser<OpCodeKind> OpCodeKinds = new();

        static readonly EnumParser<ErrorKind> ErrorKinds = new();

        static readonly EnumParser<ChipCode> ChipCodes = new();

        static readonly EnumParser<EASZ> EaszKinds = new();

        static readonly EnumParser<EOSZ> EoszKinds = new();

        static readonly EnumParser<ASZ> AszKinds = new();

        static readonly EnumParser<OSZ> OszKinds = new();

        static readonly EnumParser<ModeClass> ModeKinds = new();

        static readonly EnumParser<SMode> SModes = new();

        static XedParsers Instance = new();

        static ConcurrentDictionary<string,NontermKind> NontermUppers
            = uppers();

        static ConcurrentDictionary<string,NontermKind> uppers()
        {
            var dst = cdict<string,NontermKind>();
            var kinds =  Symbols.index<NontermKind>().Kinds;
            for(var i=0; i<kinds.Length; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                dst.TryAdd(kind.ToString().ToUpper(), kind);
            }
            return dst;
        }

        XedParsers()
        {

        }

        /// <summary>
        /// Parses an operand disassembly line
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <remarks>
        /// For example:
        /// 0		REG0/W/ZU32/EXPLICIT/NT_LOOKUP_FN/ZMM_R3
        /// 3		MEM0/R/VV/EXPLICIT/IMM_CONST/1
        /// 3		BASE0/RW/SSZ/SUPPRESSED/NT_LOOKUP_FN/SRSP
        /// </remarks>
        public static Outcome parse(string src, out OpInfo dst)
        {
            dst = default;
            if(text.length(src) < 3)
                return (false,RP.Empty);

            var result = Outcome.Success;
            var data = span(src);

            var idx = text.trim(text.left(src,2));
            result = DataParser.parse(idx, out dst.Index);
            if(result.Fail)
                return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

            var aspects = text.trim(text.right(src,2));
            var parts = text.split(aspects, Chars.FSlash);
            if(parts.Length != 6)
                return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

            var i=0;
            result = XedParsers.parse(skip(parts,i++), out dst.Name);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Name), skip(parts,i-1)));

            dst.Kind = XedRules.opkind(dst.Name);

            result = DataParser.eparse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;


            result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
            if(result.Fail)
                return result;

            result = XedParsers.parse(skip(parts,i++), out dst.Visibility);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.OpType);
            if(result.Fail)
                return result;

            var selector = text.trim(skip(parts,i++));
            dst.SelectorName = selector;
            parse(selector, out dst.Selector);
            return result;
        }

        public static bool parse(string src, out OpType dst)
            => OpTypes.Parse(src, out dst);

        public static void parse(string src, out Index<XedFlagEffect> dst)
        {
            var i = text.index(src,Chars.LBracket);
            var j = text.index(src,Chars.RBracket);
            var buffer = sys.empty<XedFlagEffect>();
            if(i >=0 && j>1)
            {
                var specs = text.split(text.despace(text.inside(src,i,j)), Chars.Space);
                var count = specs.Length;
                buffer = alloc<XedFlagEffect>(count);
                for(var k=0; k<count; k++)
                {
                    ref readonly var spec = ref skip(specs,k);
                    var m = text.index(spec,Chars.Dash);
                    if(m>0)
                    {
                        var name = text.left(spec, m);
                        var action = text.right(spec,m);
                        if(parse(name, out XedRegFlag flag) && parse(action, out FlagEffectKind ak))
                            seek(buffer,k) = new XedFlagEffect(flag, ak);
                    }
                }
            }

            dst = buffer;
        }

        public static bool parse(string src, out imm8 dst)
            => imm8.parse(src, out dst);

        public static bool parse(string src, out imm64 dst)
            => imm64.parse(src, out dst);

        public static Index<RuleSeq> ruleseq(FS.FilePath src)
            => ruleseq(src.ReadNumberedLines());

        static public Index<RuleSeq> ruleseq(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var buffer = list<RuleSeq>();
            var terms = list<RuleSeqTerm>();
            var result = Outcome.Success;
            for(var j=0u; j<count; j++)
            {
                ref readonly var line = ref skip(src,j);
                if(line.IsEmpty)
                    continue;

                var form = RuleForm(line.Content);
                if(form == RuleFormKind.SeqDecl)
                {
                    var content = text.despace(line.Content);
                    var i = text.index(content, Chars.Space);
                    var name = text.right(content, i);
                    terms.Clear();
                    j++;

                    if(parse(src, ref j, terms) != 0)
                    {
                        buffer.Add(new RuleSeq(name, terms.ToArray()));
                        terms.Clear();
                        content = text.despace(skip(src,j).Content);
                        if(IsSeqDecl(content))
                        {
                            i = text.index(content, Chars.Space);
                            name = text.right(content, i);
                            parse(name, src, ref j, buffer);
                        }
                    }
                }
            }
            return buffer.ToArray();
        }

        static void parse(Identifier name, ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeq> dst)
        {
            var content = text.despace(skip(src,j).Content);
            var terms = list<RuleSeqTerm>();
            if(parse(src, ref j, terms) != 0)
            {
                dst.Add(new RuleSeq(name, terms.ToArray()));
                content = text.despace(skip(src,j).Content);
                if(IsSeqDecl(content))
                {
                    var i = text.index(content, Chars.Space);
                    name = text.right(content, i);
                    parse(name, src, ref j, dst);
                }
            }
        }

        static uint parse(ReadOnlySpan<TextLine> src, ref uint j, List<RuleSeqTerm> terms)
        {
            var i0 = j;
            for(;j<src.Length; j++)
            {
                ref readonly var line = ref skip(src,j);
                if(line.IsEmpty)
                    break;

                if(!text.begins(line.Content, "   "))
                    break;

                var content = line.Content.Trim();
                if(text.begins(content, Chars.Hash))
                    continue;

                var q = text.index(content, Chars.Hash);
                if(q > 0)
                    content = text.left(content, q);

                if(IsNontermCall(content))
                {
                    var k = text.index(content, CallSyntax);
                    terms.Add(new RuleSeqTerm(text.left(content,k), IsNontermCall(content)));
                }
                else
                    terms.Add(new RuleSeqTerm(content, false));
            }
            return (uint)terms.Count;
        }

        public static bool IsNontermCall(string src)
            => text.trim(text.remove(src,Chars.Colon)).EndsWith("()");

        public static bool IsNontermLiteral(string src)
            => Nonterminals.Parse(src, out NontermKind _);

        public static bool IsHexLiteral(string src)
            => text.begins(src, HexFormatSpecs.PreSpec);

        public static bool IsBinaryLiteral(string src)
            => text.begins(src, "0b");

        public static bool IsIntLiteral(string src)
            => byte.TryParse(src, out _);

        public static bool IsNumber(string src)
            => IsHexLiteral(src) || IsBinaryLiteral(src) || IsIntLiteral(src);

        public static bool IsTableDecl(string src)
            => src.EndsWith(TableDeclSyntax);

        public static bool IsEncStep(string src)
            => src.Contains(EncStep);

        public static bool IsDecStep(string src)
            => src.Contains(DecStep);

        public static bool IsSeqDecl(string src)
            => src.StartsWith(SeqDeclSyntax);

        public static bool number(string src, out byte dst)
        {
            var result = false;
            dst = 0;
            if(IsHexLiteral(src))
                result = NumericParser.num8<Hex8>(src, out var value);
            else if(IsBinaryLiteral(src))
                result = NumericParser.num8<uint8b>(src, out var value);
            else
                result = NumericParser.num8(src, out var value);
            return result;
        }

        public static bool parse(string src, out bit dst)
            => bit.parse(src, out dst);

        public static bool parse(string src, out ChipCode dst)
            => ChipCodes.Parse(src, out dst);

        public static bool parse(string src, out Disp64 dst)
            => Disp64.parse(src, out dst);

        public static bool parse(string src, out ErrorKind dst)
            => ErrorKinds.Parse(text.remove(text.trim(src), "XED_ERROR_"), out dst);

        public static bool parse(string src, out VexKind dst)
            => VexKinds.Parse(src, out dst);

        public static bool parse(string src, out EASZ dst)
            => EaszKinds.Parse(src, out dst);

        public static bool parse(string src, out EOSZ dst)
            => EoszKinds.Parse(src, out dst);

        public static bool parse(string src, out ASZ dst)
            => AszKinds.Parse(src, out dst);

        public static bool parse(string src, out OSZ dst)
            => OszKinds.Parse(src, out dst);

        public static bool parse(string src, out uint1 dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out uint2 dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out uint3 dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out uint4 dst)
        {
            if(IsBinaryLiteral(src))
            {
                return DataParser.parse(src, out dst);
            }
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out uint5 dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out RuleMacroKind dst)
            => MacroKinds.Parse(src, out dst);

        public static bool parse(string src, out VisibilityKind dst)
            => VisKinds.Parse(src, out dst);

        public static bool parse(string src, out Visibility dst)
        {
            if(parse(src, out OpVisibility ov))
            {
                dst = ov;
                return true;
            }
            else if(parse(src, out VisibilityKind vk))
            {
                dst = vk;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out uint8b dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out Hex8 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);
            dst = default;
            return false;
        }

        public static bool parse(string src, out Hex16 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);
            dst = default;
            return false;
        }

        public static bool parse(string src, out ModeClass dst)
            => ModeKinds.Parse(src, out dst);

        public static bool parse(string src, out OpCodeKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public static bool parse(string src, out OpNameKind dst)
            => RuleOpNames.Parse(src, out dst);

        public static bool parse(string src, out OpName dst)
        {
            var result = parse(src, out OpNameKind kind);
            if(result)
                dst = kind;
            else
                dst = OpName.Empty;
            return result;
        }

        public static bool parse(string src, out CategoryKind dst)
            => CategoryKinds.Parse(src, out dst);

        public static bool parse(string src, out VexClass dst)
            => VexClasses.Parse(src, out dst);

        public static bool parse(string src, out Category dst)
        {
            if(parse(src, out CategoryKind kind))
            {
                dst = kind;
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        public static bool parse(string src, out IClass dst)
            => Classes.Parse(src, out dst);

        public static bool parse(string src, out InstClass dst)
        {
            if(parse(src, out IClass @class))
            {
                dst = @class;
                return true;
            }
            else
            {
                dst = InstClass.Empty;
                return false;
            }
        }

        public static bool parse(string src, out InstForm dst)
        {
            if(empty(src))
            {
                dst = InstForm.Empty;
                return true;
            }

            if(Forms.Parse(src, out IFormType type))
            {
                dst = type;
                return true;
            }
            else
            {
                dst = InstForm.Empty;
                return false;
            }
        }

        public static bool parse(string src, out IsaKind dst)
            => IsaKinds.Parse(src, out dst);

        public static bool parse(string src, out InstIsa dst)
        {
            if(parse(src, out IsaKind isa))
            {
                dst = isa;
                return true;
            }
            dst = InstIsa.Empty;
            return false;
        }

        public static bool parse(string src, out Extension dst)
        {
            dst = default;
            var result = false;
            if(parse(src, out ExtensionKind kind))
            {
                dst = kind;
                result = true;
            }
            return result;
        }

        public static bool parse(string src, out ElementType dst)
        {
            var result = ElementKinds.Parse(src, out ElementKind kind);
            dst = kind;
            return result;
        }

        public static bool parse(string src, out FlagEffectKind dst)
            => FlagActionKinds.Parse(src, out dst);

        public static bool parse(string src, out XedRegFlag dst)
            => RegFlags.Parse(src, out dst);

        public static bool parse(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public static bool parse(string src, out ushort dst)
            => ushort.TryParse(src, out dst);

        public static bool parse(string src, out FieldKind dst)
        {
            if(empty(src))
            {
                dst = 0;
                return true;
            }
            else
                return FieldKinds.Parse(src, out dst);
        }

        public static bool parse(string src, out OpWidthCode dst)
        {
            if(src == nameof(OpWidthCode.INVALID))
            {
                dst = 0;
                return true;
            }
            else
                return OpWidthParser.Parse(src, out dst);
        }

        public static bool parse(string src, out OpAction dst)
            => OpActions.Parse(src, out dst);

        public static bool parse(string src, out PointerWidth dst)
        {
            if(PointerWidths.Parse(src, out PointerWidthKind pw))
            {
                dst = pw;
                return true;
            }
            else
            {
                dst = PointerWidth.Empty;
                return false;
            }
        }

        public static bool parse(string src, out Nonterminal dst)
        {
            dst = Nonterminal.Empty;
            var input = text.trim(src.Remove(":").Remove("()"));
            var result = Nonterminals.Parse(input, out NontermKind ntk);
            if(result)
                dst = ntk;
            else
            {
                result = NontermUppers.TryGetValue(input.ToUpper(), out ntk);
                if(result)
                    dst = ntk;
            }
             return result;
        }

        public static bool parse(string src, out XedRegId dst)
        {
            var input = text.remove(text.trim(src), "XED_REG_");
            var result = Regs.Parse(input, out dst);
            if(!result)
            {
                result = FpuRegs.Parse(src, out FpuRegId fpu);
                if(result)
                    dst = (XedRegId)fpu;
            }
            return result;
        }

        public static bool parse(string src, out Register dst)
        {
            var result = parse(src, out XedRegId reg);
            if(result)
                dst = reg;
            else
                dst = Register.Empty;
            return result;
        }

        public static bool reg(FieldKind field, string value, out CellValue dst)
        {
            var result = false;
            dst = R.CellValue.Empty;
            if(IsNontermCall(value))
            {
                result = parse(value, out Nonterminal nt);
                dst = new(field, nt);
            }
            else if(parse(value, out XedRegId reg))
            {
                dst = new (field, reg);
                result = true;
            }
            else if(parse(value, out RuleKeyword keyword))
            {
                dst = new(keyword);
                result = true;
            }
            return result;
        }

        public static bool reg(string src, out OpAttrib dst)
        {
            dst = OpAttrib.Empty;
            var result = false;
            var p0 = src;
            var j = text.index(p0, Chars.LParen);
            if(j > 0)
                p0 = text.left(p0,j);

            result = parse(p0, out XedRegId regid);
            if(result)
            {
                dst = regid;
                return true;
            }

            result = IsNontermCall(src);
            if(result)
            {
                if(parse(p0, out Nonterminal nonterm))
                {
                    dst = nonterm;
                    return true;
                }
            }
            return result;
        }

        public static RF RuleForm(string src)
        {
            var i = text.index(src, Chars.Hash);
            var content = (i> 0 ? text.left(src,i) : src).Trim();
            if(IsTableDecl(content))
                return RF.RuleDecl;
            if(IsEncStep(content))
                return RF.EncodeStep;
            if(IsDecStep(content))
                return RF.DecodeStep;
            if(IsNontermCall(content))
                return RF.Invocation;
            if(IsSeqDecl(content))
                return RF.SeqDecl;
            return 0;
        }

        public static bool parse(string src, out ElementKind dst)
            => ElementKinds.Parse(src, out dst);

        public static bool parse(string src, out OpVisibility dst)
            => OpVisKinds.Parse(src, out dst);

        public static bool parse(string src, out SMode dst)
            => SModes.Parse(src, out dst);

        public static bool parse(string src, out ExtensionKind dst)
            => ExtensionKinds.Parse(src, out dst);

        public bool Parse(string src, out OpCodeKind dst)
            => OpCodeKinds.Parse(src, out dst);

        public static bool parse(string src, out BCastKind dst)
        {
            if(byte.TryParse(src, out var b))
            {
                dst = (BCastKind)b;
                return true;
            }
            dst = default;
            return false;
        }
    }
}