//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    public class XedParsers
    {
        [MethodImpl(Inline)]
        public static XedParsers create()
            => Instance;

        static XedParsers Instance = new();

        readonly EnumParser<OperandWidthKind> OpWidthParser = new();

        readonly EnumParser<OperandAction> OpActions = new();

        readonly EnumParser<PointerWidthKind> PointerWidths = new();

        readonly EnumParser<NonterminalKind> Nonterminals = new();

        readonly EnumParser<XedRegId> Regs = new();

        readonly EnumParser<ElementKind> ElementKinds = new();

        readonly EnumParser<OpVisiblity> Visibilities = new();

        readonly EnumParser<EncodingGroup> EncodingGroups = new();

        readonly EnumParser<RuleOpModKind> OpModKinds = new();

        readonly EnumParser<FieldKind> FieldKinds = new();

        readonly EnumParser<FpuRegId> FpuRegs = new();

        readonly EnumParser<IClass> Classes = new();

        readonly EnumParser<IFormType> Forms = new();

        XedParsers()
        {


        }


        public bool Num8(string src, out byte dst)
            => NumericParser.num8(src, out dst);

        public bool Parse(string src, out byte dst)
            => Num8(src, out dst);

        public bool Parse(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool FieldKind(string src, out FieldKind dst)
            => FieldKinds.Parse(src, out dst);

        public bool Parse(string src, out OperandWidthKind dst)
            => OpWidthParser.Parse(src, out dst);

        public bool OpWidth(string src, out OperandWidthKind dst)
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
            var result = Regs.Parse(src, out dst);
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

        public bool Parse(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

        public bool ElementType(string src, out ElementType dst)
        {
            var result = ElementKinds.Parse(src, out var kind);
            dst = kind;
            return result;
        }

        public bool Parse(string src, out ElementType dst)
            => ElementType(src, out dst);

        public bool OpVis(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

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