//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    public class XedParsers
    {
        [MethodImpl(Inline)]
        public static XedParsers create()
            => Instance;

        static XedParsers Instance = new();

        readonly EnumParser<OperandWidthCode> OpWidthParser = new();

        readonly EnumParser<OperandAction> OpActions = new();

        readonly EnumParser<PointerWidthKind> PointerWidths = new();

        readonly EnumParser<NonterminalKind> Nonterminals = new();

        readonly EnumParser<XedRegId> Regs = new();

        readonly EnumParser<ElementKind> ElementKinds = new();

        readonly EnumParser<OpVisibility> OpVisKinds = new();

        readonly EnumParser<EncodingGroup> EncodingGroups = new();

        readonly EnumParser<RuleOpModKind> OpModKinds = new();

        readonly EnumParser<FieldKind> FieldKinds = new();

        readonly EnumParser<FpuRegId> FpuRegs = new();

        readonly EnumParser<IClass> Classes = new();

        readonly EnumParser<IFormType> Forms = new();

        XedParsers()
        {

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

        public static bool parse(string src, out EncodingGroup dst)
            => Instance.Parse(src, out dst);

        public bool Num8(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public bool Parse(string src, out byte dst)
            => Num8(src, out dst);

        public bool Parse(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool FieldKind(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool Parse(string src, out OperandWidthCode dst)
            => OpWidthParser.Parse(src, out dst);

        public bool OpWidth(string src, out OperandWidthCode dst)
            => OpWidthParser.Parse(src, out dst);

        public bool Parse(string src, out OperandAction dst)
            => OpActions.Parse(src, out dst);

        public bool Action(string src, out OperandAction dst)
            => OpActions.Parse(src, out dst);

        public bool Parse(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool PtrWidth(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool Parse(string src, out NonterminalKind dst)
            => Nonterminals.Parse(src, out dst);

        public bool Nonterm(string src, out NonterminalKind dst)
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

        public bool RegLiteral(string src, out XedRegId dst)
            => Parse(src, out dst);

        public bool Parse(string src, out ElementKind dst)
            => ElementKinds.Parse(src, out dst);

        public bool ElementKind(string src, out ElementKind dst)
            => ElementKinds.Parse(src, out dst);

        public bool Parse(string src, out OpVisibility dst)
            => OpVisKinds.Parse(src, out dst);

        public bool ElementType(string src, out ElementType dst)
        {
            var result = ElementKinds.Parse(src, out var kind);
            dst = kind;
            return result;
        }

        public bool Parse(string src, out ElementType dst)
            => ElementType(src, out dst);

        public bool OpVis(string src, out OpVisibility dst)
            => OpVisKinds.Parse(src, out dst);

        public bool Parse(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool EncodingGroup(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool Parse(string src, out RuleOpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public bool OpKind(string src, out RuleOpModKind dst)
            => OpModKinds.Parse(src, out dst);

        public bool Parse(string src, out IClass dst)
            => Classes.Parse(src, out dst);

        public bool IClass(string src, out IClass dst)
            => Classes.Parse(src, out dst);

        public bool Form(string src, out IForm dst)
        {
            var result = Forms.Parse(src, out var type);
            dst = type;
            return result;
        }

        public bool Parse(string src, out IForm dst)
            => Form(src, out dst);
    }
}