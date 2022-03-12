//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedRules.SyntaxLiterals;
    using static core;

    public class XedParsers
    {
        [MethodImpl(Inline)]
        public static XedParsers create()
            => Instance;

        public static XedParsers Service => Instance;

        static XedParsers Instance = new();

        readonly EnumParser<OperandWidthCode> OpWidthParser = new();

        readonly EnumParser<OperandAction> OpActions = new();

        readonly EnumParser<PointerWidthKind> PointerWidths = new();

        readonly EnumParser<NonterminalKind> Nonterminals = new();

        readonly EnumParser<XedRegId> Regs = new();

        readonly EnumParser<ElementKind> ElementKinds = new();

        readonly EnumParser<OpVisibility> OpVisKinds = new();

        readonly EnumParser<GroupName> EncodingGroups = new();

        readonly EnumParser<RuleOpModKind> OpModKinds = new();

        readonly EnumParser<FieldKind> FieldKinds = new();

        readonly EnumParser<FpuRegId> FpuRegs = new();

        readonly EnumParser<IClass> Classes = new();

        readonly EnumParser<IFormType> Forms = new();

        readonly EnumParser<ExtensionKind> ExtensionKinds = new();

        readonly EnumParser<FlagActionKind> FlagActionKinds = new();

        readonly EnumParser<RegFlag> RegFlags = new();

        readonly EnumParser<IsaKind> IsaKinds = new();

        readonly EnumParser<CategoryKind> CategoryKinds = new();

        readonly EnumParser<RuleOpName> RuleOpNames = new();

        readonly EnumParser<RuleMacroKind> MacroKinds = new();

        XedParsers()
        {

        }

        public static Outcome parse(string src, out Index<InstDefSeg> dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleMacroKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleToken dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out FieldAssign dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out uint8b dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out NontermCall dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out FieldConstraint dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out ConstraintKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out Hex8 dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out BitfieldSeg dst)
            => Instance.Parse(src, out dst);

        public static Outcome parse(string src, out DispFieldSpec dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out ImmFieldSpec dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleOpModKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleOpName dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out CategoryKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out Category dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out IClass dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out IForm dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out IsaKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out Extension dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out ElementType dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out FlagActionKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RegFlag dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out byte dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out FieldKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OperandWidthCode dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OperandAction dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out PointerWidthKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out NonterminalKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out XedRegId dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out ElementKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OpVisibility dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out GroupName dst)
            => Instance.Parse(src, out dst);

        public bool Num8(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public bool Parse(string src, out byte dst)
            => Num8(src, out dst);

        public bool Parse(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool Parse(string src, out RuleMacroKind dst)
            => MacroKinds.Parse(src, out dst);

        public bool Parse(string src, out ExtensionKind dst)
            => ExtensionKinds.Parse(src, out dst);

        public bool Parse(string src, out OperandWidthCode dst)
            => OpWidthParser.Parse(src, out dst);

        public bool Parse(string src, out OperandAction dst)
            => OpActions.Parse(src, out dst);

        public bool Parse(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool Parse(string src, out IsaKind dst)
            => IsaKinds.Parse(src, out dst);

        public bool Parse(string src, out NonterminalKind dst)
            => Nonterminals.Parse(src, out dst);

        public bool Parse(string src, out XedRegId dst)
        {
            var input = text.remove(text.trim(src), "XED_REG_");
            var result = Regs.Parse(input, out dst);
            if(!result)
            {
                result = FpuRegs.Parse(src, out var fpu);
                if(result)
                    dst = (XedRegId)fpu;
            }
            return result;
        }

        public bool Parse(string src, out ElementKind dst)
            => ElementKinds.Parse(src, out dst);

        public bool Parse(string src, out OpVisibility dst)
            => OpVisKinds.Parse(src, out dst);

        public bool Parse(string src, out Extension dst)
        {
            dst = default;
            var result = false;
            if(Parse(src, out ExtensionKind kind))
            {
                dst = kind;
                result = true;
            }
            return result;
        }

        public bool Parse(string src, out ElementType dst)
        {
            var result = ElementKinds.Parse(src, out var kind);
            dst = kind;
            return result;
        }

       public bool Parse(string src, out RegFlag dst)
            => RegFlags.Parse(src, out dst);

        public bool Parse(string src, out GroupName dst)
            => EncodingGroups.Parse(src, out dst);

        public bool Parse(string src, out RuleOpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public bool Parse(string src, out FlagActionKind dst)
            => FlagActionKinds.Parse(src, out dst);

       public bool Parse(string src, out RuleOpName dst)
            => RuleOpNames.Parse(src, out dst);

        public bool Parse(string src, out IClass dst)
            => Classes.Parse(src, out dst);

        public bool Parse(string src, out CategoryKind dst)
            => CategoryKinds.Parse(src, out dst);

        public bool Parse(string src, out Category dst)
        {
            if(Parse(src, out CategoryKind kind))
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

        public bool Parse(string src, out BitfieldSeg dst)
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
                    var literal = text.begins(content,"0b");
                    dst = new BitfieldSeg(kind, text.remove(content,"0b"), literal);
                    result = true;
                }
            }
            return result;
        }

        public Outcome Parse(string src, out DispFieldSpec dst)
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

        public Outcome Parse(string src, out ImmFieldSpec dst)
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

        public bool Parse(string src, out ConstraintKind kind)
        {
            kind = 0;
            if(text.contains(src, "!="))
            {
                kind = ConstraintKind.Neq;
            }
            else if(text.contains(src, "="))
            {
                kind = ConstraintKind.Eq;
            }
            return kind != 0;
        }

        public bool Parse(string src, out IForm dst)
        {
            var result = Forms.Parse(src, out var type);
            dst = type;
            return result;
        }

        [MethodImpl(Inline)]
        public bool Parse(string src, out Hex8 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);

            dst = default;
            return false;
        }

        public bool Parse(string src, out FieldConstraint dst)
        {
            dst = FieldConstraint.Empty;
            var result = false;
            if(Parse(src, out ConstraintKind ck))
            {
                var expr = XedRender.format(ck);
                var i = text.index(src,expr);
                if(i > 0)
                {
                    var a = text.left(src,i);
                    var b = text.right(src,i + expr.Length - 1);
                    result =Parse(a, out FieldKind fk);
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
                        result = NumericParser.num8<uint8b>(b, out var value);
                        dst = new FieldConstraint(fk, ck, value, FieldLiteralKind.DecimalLiteral);
                    }
                }
            }
            return result;
        }

        public bool Parse(string src, out uint8b dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public bool Parse(string src, out uint5 dst)
        {
            if(IsBinaryLiteral(src))
                return DataParser.parse(src, out dst);
            else
            {
                dst = default;
                return false;
            }
        }

        public bool Parse(string src, out NontermCall dst)
        {
            var result = false;
            dst = NontermCall.Empty;

            if(call(src, out var name))
            {
                result = parse(name, out NonterminalKind kind);
                if(result)
                    dst = kind;
            }

            static bool call(string src, out string name)
            {
                var result = false;
                name = EmptyString;
                if(text.ends(src, "()"))
                {
                    var i = text.index(src,Chars.LParen);
                    name = text.left(src,i);
                    result = true;
                }
                return result;
            }

            return result;
        }

        public Outcome Parse(string src, out FieldAssign dst)
        {
            var i = text.index(src,Chars.Eq);
            dst = FieldAssign.Empty;
            var result = Outcome.Failure;
            if(i > 0)
            {
                var name = text.left(src,i);
                var val = text.right(src,i);
                if(Parse(name, out FieldKind fk))
                {
                    if(Parse(val, out uint8b b))
                    {
                        dst = assign(fk,b);
                        result = true;
                    }
                    else if(Parse(val, out Hex8 h))
                    {
                        dst = assign(fk,h);
                        result = true;
                    }
                    else if(ulong.TryParse(val, out var d))
                    {
                        dst = assign(fk,d);
                        result = true;
                    }
                    else
                        result = (false, AppMsg.ParseFailure.Format(fk.ToString(), val));
                }
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldKind), src));
            }
            return result;
        }

        public bool Parse(string src, out RuleToken dst)
        {
            var result = false;
            dst = RuleToken.Empty;
            if(Parse(src, out BitfieldSeg bfs))
            {
                dst = new(bfs);
                result = true;
            }
            else if(Parse(src, out uint8b bin))
            {
                dst = new(bin);
                result = true;
            }
            else if(Parse(src, out Hex8 hex))
            {
                dst = new(hex);
                result = true;
            }
            else if(Parse(src, out NontermCall nt))
            {
                dst = new(nt);
                result = true;
            }
            else if(Parse(src, out RuleMacroKind m))
            {
                dst = new(m);
                result = true;
            }
            else if(Parse(src, out ConstraintKind ck))
            {
                var expr = XedRender.format(ck);
                var i = text.index(src,expr);
                if(i > 0)
                {
                    var a = text.left(src,i);
                    var b = text.right(src,i + expr.Length - 1);
                    result = Parse(src, out FieldConstraint c);
                    dst = new(c);
                }
            }
            else if(Parse(src, out FieldAssign assign))
            {
                dst = new(assign);
                result = true;
            }
            return result;
        }

        public Outcome Parse(string src, out Index<InstDefSeg> dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src), Chars.Space));
            var count = parts.Length;
            dst = alloc<InstDefSeg>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(parts,i);
                result = Parse(part, out dst[i]);
                if(result.Fail)
                    break;
            }

            return result;
        }

        Outcome Parse(string src, out InstDefSeg dst)
        {
            dst = InstDefSeg.Empty;
            Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
            if(IsHexLiteral(src))
            {
                result = Parse(src, out Hex8 x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
            }
            else if(IsBinaryLiteral(src))
            {
                result = Parse(src, out uint5 x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

            }
            else if(IsBitfieldSeg(src))
            {
                result = Parse(src, out BitfieldSeg x);
                if(result)
                    dst = x;
            }
            else if(IsNeq(src))
            {
                result = Parse(src, out FieldConstraint x);
                if(result)
                    dst = x;
                else
                    result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

            }
            else if(IsAssign(src))
            {
                result = Parse(src, out FieldAssign x);
                if(result)
                    dst = x;
            }
            else if(IsCall(src))
            {
                result = Parse(src, out NontermCall x);
                if(result)
                    dst = x;

            }
            return result;
        }

        [MethodImpl(Inline)]
        static bool IsHexLiteral(string src)
            => text.begins(src, HexFormatSpecs.PreSpec);

        [MethodImpl(Inline)]
        static bool IsBinaryLiteral(string src)
            => text.begins(src, "0b");
    }
}