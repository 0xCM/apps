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

    using R = XedRules;

    public partial class XedParsers
    {
        public static XedParsers Service => Instance;

        static XedParsers Instance = new();

        XedParsers()
        {

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
            => SQ.digits(base10,src) != 0;

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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out Nonterminal dst)
        {
            dst = new Nonterminal(text.remove(src,"()"));
            return true;
        }

        public static bool parse(string src, out ChipCode dst)
            => ChipCodes.Parse(src, out dst);

        public static bool parse(string src, out ErrorKind dst)
            => Instance.Parse(src,out dst);

        public static bool parse(string src, out VexKind dst)
            => VexKinds.Parse(src, out dst);

        public static bool parse(string src, out EASZ dst)
            => Instance.Parse(src,out dst);

        public static bool parse(string src, out EOSZ dst)
            => Instance.Parse(src,out dst);

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

        public static Outcome parse(string src, out InstPatternBody dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src), Chars.Space));
            var count = parts.Length;
            dst = alloc<InstDefPart>(count);
            for(var i=0; i<count; i++)
            {
                ref var target = ref dst[i];
                ref readonly var part = ref skip(parts,i);
                result = parse(part, out target);
                if(result.Fail)
                {
                    break;
                }
            }

            return result;
        }

        public static bool parse(string src, out RuleMacroKind dst)
            => Instance.Parse(src, out dst);

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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out Hex8 dst)
            => Instance.Parse(src, out dst);

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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OpCodeKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleOpModKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out RuleOpName dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out CategoryKind dst)
            => CategoryKinds.Parse(src, out dst);

        public static bool parse(string src, out VexClass dst)
            => Instance.Parse(src, out dst);

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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out IForm dst)
        {
            var result = Forms.Parse(src, out IFormType type);
            dst = type;
            return result;
        }

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

        public static bool parse(string src, out OpWidthCode dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out OpAction dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out PointerWidthKind dst)
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out NontermKind dst)
            => Nonterminals.Parse(src, out dst);

        public static bool parse(string src, out GroupName dst)
            => Instance.Parse(src, out dst);

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

        public static bool reg(string src, out RuleOpAttrib dst)
        {
            dst = RuleOpAttrib.Empty;
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
            => Instance.Parse(src, out dst);

        public static bool parse(string src, out SMode dst)
            => Instance.Parse(src, out dst);

        public bool Num8(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public bool Parse(string src, out byte dst)
            => Num8(src, out dst);

        public bool Parse(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool Parse(string src, out RuleMacroKind dst)
            => MacroKinds.Parse(src, out dst);

        public bool Parse(string src, out EASZ dst)
            => EaszKinds.Parse(src, out dst);

        public bool Parse(string src, out EOSZ dst)
            => EoszKinds.Parse(src, out dst);

        public bool Parse(string src, out ExtensionKind dst)
            => ExtensionKinds.Parse(src, out dst);

        public bool Parse(string src, out VexClass dst)
            => VexClasses.Parse(src, out dst);

        public bool Parse(string src, out OpWidthCode dst)
            => OpWidthParser.Parse(src, out dst);

        public bool Parse(string src, out OpAction dst)
            => OpActions.Parse(src, out dst);

        public bool Parse(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool Parse(string src, out IsaKind dst)
            => IsaKinds.Parse(src, out dst);

        public bool Parse(string src, out ErrorKind dst)
            => ErrorKinds.Parse(text.remove(text.trim(src), "XED_ERROR_"), out dst);

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
            var result = ElementKinds.Parse(src, out ElementKind kind);
            dst = kind;
            return result;
        }

        public bool Parse(string src, out RegFlag dst)
            => RegFlags.Parse(src, out dst);

        public bool Parse(string src, out GroupName dst)
            => GroupNames.Parse(src, out dst);

        public bool Parse(string src, out RuleOpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public bool Parse(string src, out FlagActionKind dst)
            => FlagActionKinds.Parse(src, out dst);

        public bool Parse(string src, out bit dst)
            => bit.parse(src, out dst);

        public bool Parse(string src, out RuleOpName dst)
            => RuleOpNames.Parse(src, out dst);

        public bool Parse(string src, out SMode dst)
            => SModes.Parse(src, out dst);

        public bool Parse(string src, out IClass dst)
            => Classes.Parse(src, out dst);

        public bool Parse(string src, out OpCodeKind dst)
            => OpCodeKinds.Parse(src, out dst);

        public bool Parse(string src, out ModeKind dst)
            => ModeKinds.Parse(src, out dst);

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

        [MethodImpl(Inline)]
        public bool Parse(string src, out Hex8 dst)
        {
            if(IsHexLiteral(src))
                return DataParser.parse(src, out dst);
            dst = default;
            return false;
        }

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
            if(XedParsers.parse(src, out uint8b a))
            {
                dst = XedFields.value(kind, a);
                result = true;
            }
            else if(XedParsers.parse(src, out Hex8 b))
            {
                dst = XedFields.value(kind, b);
                result = true;
            }
            else if(XedParsers.parse(src, out byte c))
            {
                dst = XedFields.value(kind, c);
                result = true;
            }
            else if(ushort.TryParse(src, out var d))
            {
                dst = XedFields.value(kind, d);
                result = true;
            }

            return result;
        }


    }
}