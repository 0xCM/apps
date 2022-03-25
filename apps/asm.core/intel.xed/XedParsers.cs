//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedPatterns;
    using static XedRules.SyntaxLiterals;
    using static core;
    using Asm;

    using R = XedRules;

    public partial class XedParsers
    {
        static readonly EnumParser<OpWidthCode> OpWidthParser = new();

        static readonly EnumParser<OpAction> OpActions = new();

        static readonly EnumParser<PointerWidthKind> PointerWidths = new();

        static readonly EnumParser<NontermKind> Nonterminals = new();

        static readonly EnumParser<XedRegId> Regs = new();

        static readonly EnumParser<ElementKind> ElementKinds = new();

        static readonly EnumParser<OpVisibility> OpVisKinds = new();

        static readonly EnumParser<GroupName> GroupNames = new();

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

        static readonly EnumParser<OpName> RuleOpNames = new();

        static readonly EnumParser<RuleMacroKind> MacroKinds = new();

        static readonly EnumParser<VexClass> VexClasses = new();

        static readonly EnumParser<VexKind> VexKinds = new();

        static readonly EnumParser<OpCodeKind> OpCodeKinds = new();

        static readonly EnumParser<ErrorKind> ErrorKinds = new();

        static readonly EnumParser<ChipCode> ChipCodes = new();

        static readonly EnumParser<EASZ> EaszKinds = new();

        static readonly EnumParser<EOSZ> EoszKinds = new();

        static readonly EnumParser<ModeKind> ModeKinds = new();

        static readonly EnumParser<SMode> SModes = new();

        static XedParsers Instance = new();

        XedParsers()
        {

        }

        public static Outcome parse(string src, out InstPatternBody dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src), Chars.Space));
            var count = parts.Length;
            dst = alloc<InstDefField>(count);
            for(var i=0; i<count; i++)
            {
                result = XedParsers.parse(skip(parts,i), out dst[i]);
                if(result.Fail)
                    break;
            }
            return result;
        }

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

        public static Outcome parse(string src, out InstDefField dst)
        {
            dst = InstDefField.Empty;
            Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
            if(IsHexLiteral(src))
            {
                result = parse(src, out Hex8 x);
                if(result)
                    dst = part(x);
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
            }
            else if(IsBinaryLiteral(src))
            {
                result = parse(src, out uint5 x);
                if(result)
                    dst = part(x);
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

            }
            else if(IsBfSeg(src))
            {
                result = parse(src, out BitfieldSeg x);
                if(result)
                    dst = part(x);
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(BitfieldSeg), src));
            }
            else if(IsCmpNeq(src))
            {
                result = parse(src, out FieldConstraint x);
                if(result)
                    dst = part(x);
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

            }
            else if(IsAssignment(src))
            {
                result = parse(src, out FieldAssign x);
                if(result)
                {
                    dst = part(x);
                }
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldAssign), src));

            }
            else if(IsNonterminal(src))
            {
                result = parse(src, out Nonterminal x);
                if(result)
                    dst = part(x);
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
            }
            else if (parse(src, out byte a))
            {
                result = true;
                dst = new(a);
            }

            return result;
        }

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

                var form = XedRules.RuleForm(line.Content);
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

                if(IsNonterminal(content))
                {
                    var k = text.index(content, CallSyntax);
                    terms.Add(new RuleSeqTerm(text.left(content,k), IsNonterminal(content)));
                }
                else
                    terms.Add(new RuleSeqTerm(content, false));
            }
            return (uint)terms.Count;
        }

        public static bool IsAssignment(string src)
            => src.Contains(SyntaxLiterals.Assign) && !IsCmp(src);

        public static bool IsCmp(string src)
            => IsCmpEq(src) || IsCmpNeq(src);

        public static bool IsCmpEq(string src)
            => src.Contains("==");

        public static bool IsCmpNeq(string src)
            => src.Contains(Neq);

        public static bool IsNonterminal(string src)
            => text.trim(text.remove(src,"::")).EndsWith("()");

        [MethodImpl(Inline)]
        public static bool IsHexLiteral(string src)
            => text.begins(src, HexFormatSpecs.PreSpec);

        [MethodImpl(Inline)]
        public static bool IsBinaryLiteral(string src)
            => text.begins(src, "0b");

        [MethodImpl(Inline)]
        public static bool IsIntLiteral(string src)
            => Digital.count(base10,src) != 0;

        public static bool IsBfSeg(string src)
        {
            var i = text.index(src, Chars.LBracket);
            var j = text.index(src, Chars.RBracket);
            return i > 0 && j > i;
        }

        public static bool IsBfSpec(string src)
            => text.index(src,Chars.Underscore) > 0;

        public static bool IsTableDecl(string src)
            => src.EndsWith(TableDeclSyntax);

        public static bool IsEncStep(string src)
            => src.Contains(EncStep);

        public static bool IsDecStep(string src)
            => src.Contains(DecStep);

        public static bool IsSeqDecl(string src)
            => src.StartsWith(SeqDeclSyntax);

        public static bool num8(string src, out byte dst)
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

        public static bool parse(string src, out Nonterminal dst)
        {
            dst = new Nonterminal(text.remove(src,"()"));
            return true;
        }

        public static bool parse(string src, out ChipCode dst)
            => ChipCodes.Parse(src, out dst);

        public static bool parse(string src, out ErrorKind dst)
            => ErrorKinds.Parse(text.remove(text.trim(src), "XED_ERROR_"), out dst);

        public static bool parse(string src, out VexKind dst)
            => VexKinds.Parse(src, out dst);

        public static bool parse(string src, out EASZ dst)
            => Instance.Parse(src,out dst);

        public static bool parse(string src, out EOSZ dst)
            => EoszKinds.Parse(src, out dst);

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

        public static bool parse(string src, out FieldConstraint dst)
        {
            dst = FieldConstraint.Empty;
            var result = false;
            if(parse(src, out ConstraintKind ck))
            {
                var expr = XedRender.format(ck);
                var i = text.index(src,expr);
                if(i > 0)
                {
                    var a = text.left(src,i);
                    var b = text.right(src,i + expr.Length - 1);
                    result = parse(a, out FieldKind fk);
                    Require.invariant(result);
                    if(IsHexLiteral(a))
                    {
                        result = NumericParser.num8<Hex8>(b, out var value);
                        dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.HexLiteral);
                    }
                    else if(IsBinaryLiteral(a))
                    {
                        result = NumericParser.num8<uint8b>(b, out var value);
                        dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.BinaryLiteral);
                    }
                    else
                    {
                        result = NumericParser.num8(b, out var value);
                        dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.DecimalLiteral);
                    }
                }
            }
            return result;
        }

        public static bool parse(string src, out ConstraintKind dst)
        {
            dst = 0;
            if(text.contains(src, "!="))
                dst = ConstraintKind.Neq;
            else if(text.contains(src, "="))
                dst = ConstraintKind.Eq;
            return dst != 0;
        }

        public static bool parse(string src, out Hex8 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);
            dst = default;
            return false;
        }

        public static bool parse(string src, out BitfieldSeg dst)
        {
            var name = EmptyString;
            var content = EmptyString;
            dst = default;
            var i = text.index(src, Chars.LBracket);
            var j = text.index(src, Chars.RBracket);
            var result = false;
            if(i > 0 && j > i)
            {
                name = text.left(src,i);
                content = text.inside(src,i,j);
                if(parse(name, out FieldKind kind))
                {
                    dst = new BitfieldSeg(kind, text.remove(content,"0b"), text.begins(content,"0b"));
                    result = true;
                }
            }
            return result;
        }

        public static bool Assignment(string src, out string left, out string right)
        {
            var result = false;
            if(IsAssignment(src))
            {
                var i = text.index(src, Chars.Eq);
                left = text.left(src,i);
                right = text.right(src,i);
                result = true;
            }
            else
            {
                left = EmptyString;
                right = EmptyString;
            }
            return result;
        }

        public static bool CmpNeq(string src, out string left, out string right)
        {
            var result = false;
            if(IsCmpNeq(src))
            {
                var i = text.index(src, Chars.Bang);
                left = text.left(src,i);
                right = text.right(src,i+1);
                result = true;
            }
            else
            {
                left = EmptyString;
                right = EmptyString;
            }
            return result;
        }

        public static bool CmpEq(string src, out string left, out string right)
        {
            var result = false;
            if(IsCmpEq(src))
            {
                var i = text.index(src, Chars.Eq);
                left = text.left(src,i);
                right = text.right(src,i+1);
                result = true;
            }
            else
            {
                left = EmptyString;
                right = EmptyString;
            }
            return result;
        }

        public static Outcome parse(string src, out DispFieldSpec dst)
        {
            var result = Outcome.Success;
            dst = DispFieldSpec.Empty;
            var i = text.index(src, Chars.LBracket);
            var j = text.index(src, Chars.RBracket);
            var kind = Chars.x;
            var width = z8;
            if(i > 0 && j > i)
            {
                var inside = text.inside(src,i,j);
                var quotient = text.split(inside,Chars.FSlash);
                if(quotient.Length != 2)
                    return (false,AppMsg.ParseFailure.Format(nameof(DispFieldSpec), src));

                ref readonly var upper = ref skip(quotient,0);
                ref readonly var lower = ref skip(quotient,1);
                if(upper.Length == 1)
                    kind = upper[0];
                if(!byte.TryParse(lower, out width))
                    return (false, AppMsg.ParseFailure.Format(nameof(width), lower));
            }

            dst = new DispFieldSpec(width, kind);
            return result;
        }

        public static bool parse(string src, out FieldLiteral dst)
        {
            var input = text.trim(src);
            dst = FieldLiteral.Empty;
            if(input.Length > 8)
                return false;
            else if(IsBinaryLiteral(input))
            {
                dst = FieldLiteral.Binary(input);
                return true;
            }

            switch(input)
            {
                case "else":
                case "default":
                    dst = FieldLiteral.Default;
                break;
                case "null":
                    dst = FieldLiteral.Null;
                break;
                case "error":
                    dst = FieldLiteral.Error;
                break;
                case "@":
                    dst = FieldLiteral.Wildcard;
                break;
                default:
                    dst = FieldLiteral.Text(input);
                break;
            }

            return true;
        }

        public static bool parse(string src, out ImmFieldSpec dst)
        {
            var i = text.index(src, Chars.LBracket);
            var j = text.index(src, Chars.RBracket);
            var kind = Chars.x;
            var width = z8;
            var index = z8;
            var result = Outcome.Success;

            if(text.contains(src,"UIMM1"))
                index = 1;

            if(i > 0 && j > i)
            {
                var inside = text.inside(src,i,j);
                var quotient = text.split(inside,Chars.FSlash);
                if(quotient.Length != 2)
                    result = (false,AppMsg.ParseFailure.Format(nameof(DispFieldSpec), src));

                else
                {
                    ref readonly var upper = ref skip(quotient,0);
                    ref readonly var lower = ref skip(quotient,1);

                    if(upper.Length == 1)
                        kind = upper[0];
                    if(!byte.TryParse(lower, out width))
                        result = (false,AppMsg.ParseFailure.Format(nameof(width), lower));
                }
            }

            dst = new ImmFieldSpec(index, width);
            return result;
        }

        public static Outcome parse(string src, out ModeKind dst)
            => ModeKinds.Parse(src, out dst);

        public static bool parse(string src, out OpCodeKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public static bool parse(string src, out OpName dst)
            => Instance.Parse(src, out dst);

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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out XedRegFlag dst)
            => RegFlags.Parse(src, out dst);

        public static bool parse(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public static bool parse(string src, out ushort dst)
            => ushort.TryParse(src, out dst);

        public static bool parse(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public static bool parse(string src, out OpWidthCode dst)
            => OpWidthParser.Parse(src, out dst);

        public static bool parse(string src, out OpAction dst)
            => OpActions.Parse(src, out dst);

        public static bool parse(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public static bool parse(string src, out NontermKind dst)
            => Nonterminals.Parse(src, out dst);

        public static bool parse(string src, out GroupName dst)
            => GroupNames.Parse(src, out dst);

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

        public static bool reg(FieldKind field, string value, out R.FieldValue dst)
        {
            var result = false;
            dst = R.FieldValue.Empty;
            if(IsNonterminal(value))
                dst = new(field, new Nonterminal(value));
            else if(parse(value, out XedRegId reg))
            {
                dst = new (field, reg);
                result = true;
            }
            else if(parse(value, out FieldLiteral fl))
            {
                dst = new(field, (ulong)fl.ToAsci());
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

            result = parse(p0, out NontermKind nk);
            if(result)
            {
                dst = new Nonterminal(p0);
                return true;
            }

            result = parse(p0, out GroupName gn);
            if(result)
            {
                dst = new Nonterminal(p0);
                return true;
            }

            result = IsNonterminal(src);
            if(result)
            {
                dst = new Nonterminal(p0);
                return true;
            }
            return result;
        }

        public static bool parse(string src, out ElementKind dst)
            => ElementKinds.Parse(src, out dst);

        public static bool parse(string src, out OpVisibility dst)
            => OpVisKinds.Parse(src, out dst);

        public static bool parse(string src, out SMode dst)
            => Instance.Parse(src, out dst);

        public bool Num8(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public bool Parse(string src, out byte dst)
            => Num8(src, out dst);

        public bool Parse(string src, out EASZ dst)
            => EaszKinds.Parse(src, out dst);

        public static bool parse(string src, out ExtensionKind dst)
            => ExtensionKinds.Parse(src, out dst);

        public bool Parse(string src, out FlagEffectKind dst)
            => FlagActionKinds.Parse(src, out dst);

        public bool Parse(string src, out OpName dst)
            => RuleOpNames.Parse(src, out dst);

        public bool Parse(string src, out SMode dst)
            => SModes.Parse(src, out dst);

        public bool Parse(string src, out OpCodeKind dst)
            => OpCodeKinds.Parse(src, out dst);

        public static bool parse(string src, out FieldAssign dst)
        {
            var input = text.trim(src);
            var i = text.index(input, Chars.Eq);
            dst = FieldAssign.Empty;
            Outcome result = (false, AppMsg.ParseFailure.Format(nameof(FieldAssign), src));
            if(i > 0)
            {
                if(parse(text.left(input,i), out FieldKind kind))
                    if(parse(kind, text.right(input,i), out var fv))
                    {
                        dst = new(fv);
                        result = true;
                    }
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldKind), src));
            }
            return result;
        }

        public static Outcome parse(FieldKind kind, string src, out R.FieldValue dst)
        {
            Outcome result = (false,AppMsg.ParseFailure.Format(kind.ToString(), src));
            dst = R.FieldValue.Empty;
            if(parse(src, out uint8b a))
            {
                dst = XedFields.value(kind, a);
                result = true;
            }
            else if(parse(src, out Hex8 b))
            {
                dst = XedFields.value(kind, b);
                result = true;
            }
            else if(parse(src, out byte c))
            {
                dst = XedFields.value(kind, c);
                result = true;
            }
            else if(parse(src, out ushort d))
            {
                dst = XedFields.value(kind, d);
                result = true;
            }

            return result;
        }
    }
}