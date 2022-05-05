//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public record struct OpSpec
        {
            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public OpAction Action;

            public Visibility Visibility;

            public OpWidthCode WidthCode;

            public ushort BitWidth;

            public ElementType ElementType;

            public ushort ElementWidth;

            public byte ElementCount;

            public BitSegType SegType;

            public OpType OpType;

            public Nonterminal Rule;

            public asci16 Selector;

            public const string RenderPattern = "{0} | {1,-6} | {2,-4} | {3,-4} | {4,-4} | {5,-16} | {6}";

            public string Format()
            {
                return string.Format(RenderPattern,
                        Index,
                        XedRender.format(Name),
                        XedRender.format(Action),
                        XedRender.format(WidthCode),
                        Visibility.Code(),
                        XedRender.format(OpType),
                        Rule.IsNonEmpty
                        ? string.Format("{0} => {1}", Rule, XedPaths.Service.RulePage(new RuleSig(RuleTableKind.DEC, Rule.Name)))
                        : Selector
                    );
            }

            public override string ToString()
                => XedRender.format(Index,this);
        }
    }
}