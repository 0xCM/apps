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

        readonly EnumParser<ElementType> ElementTypes = new();

        readonly EnumParser<OpVisiblity> Visibilities = new();

        readonly EnumParser<EncodingGroup> EncodingGroups = new();

        readonly EnumParser<TextPropKind> TextProps = new();

        readonly EnumParser<FieldKind> FieldKinds = new();

        XedParsers()
        {


        }

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
            => Regs.Parse(src, out dst);

        public bool RegLiteral(string src, out XedRegId dst)
            => Regs.Parse(src, out dst);

        public bool Parse(string src, out ElementType dst)
            => ElementTypes.Parse(src, out dst);

        public bool ElementType(string src, out ElementType dst)
            => ElementTypes.Parse(src, out dst);

        public bool Parse(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

        public bool OpVis(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

        public bool Parse(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool Group(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool Parse(string src, out TextPropKind dst)
            => TextProps.Parse(src, out dst);

        public bool TextProp(string src, out TextPropKind dst)
            => TextProps.Parse(src, out dst);
    }
}