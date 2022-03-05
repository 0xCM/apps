//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    public class XedParsers
    {
        public static XedParsers create()
            => new XedParsers();

        readonly EnumParser<OperandWidthKind> OpWidthParser = new();

        readonly EnumParser<OperandAction> OpActions = new();

        readonly EnumParser<PointerWidthKind> PointerWidths = new();

        readonly EnumParser<NonterminalKind> Nonterminals = new();

        readonly EnumParser<XedRegId> Regs = new();

        readonly EnumParser<ElementType> ElementTypes = new();

        readonly EnumParser<OpVisiblity> Visibilities = new();

        readonly EnumParser<EncodingGroup> EncodingGroups = new();

        readonly EnumParser<TextPropKind> TextProps = new();

        XedParsers()
        {


        }

        public bool Parse(string src, out OperandWidthKind dst)
            => OpWidthParser.Parse(src, out dst);

        public bool ParseOpWidth(string src, out OperandWidthKind dst)
            => OpWidthParser.Parse(src, out dst);

        public bool Parse(string src, out OperandAction dst)
            => OpActions.Parse(src, out dst);

        public bool ParseAction(string src, out OperandAction dst)
            => OpActions.Parse(src, out dst);

        public bool Parse(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool ParsePtrWidth(string src, out PointerWidthKind dst)
            => PointerWidths.Parse(src, out dst);

        public bool Parse(string src, out NonterminalKind dst)
            => Nonterminals.Parse(src, out dst);

        public bool ParseNonterm(string src, out NonterminalKind dst)
            => Nonterminals.Parse(src, out dst);

        public bool Parse(string src, out XedRegId dst)
            => Regs.Parse(src, out dst);

        public bool ParseRegLiteral(string src, out XedRegId dst)
            => Regs.Parse(src, out dst);

        public bool Parse(string src, out ElementType dst)
            => ElementTypes.Parse(src, out dst);

        public bool ParseElementType(string src, out ElementType dst)
            => ElementTypes.Parse(src, out dst);

        public bool Parse(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

        public bool ParseVisibility(string src, out OpVisiblity dst)
            => Visibilities.Parse(src, out dst);

        public bool Parse(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool ParseGroup(string src, out EncodingGroup dst)
            => EncodingGroups.Parse(src, out dst);

        public bool Parse(string src, out TextPropKind dst)
            => TextProps.Parse(src, out dst);

        public bool ParseTextProp(string src, out TextPropKind dst)
            => TextProps.Parse(src, out dst);
    }
}