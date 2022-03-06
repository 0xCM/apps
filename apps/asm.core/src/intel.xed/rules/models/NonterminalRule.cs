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
        public readonly struct NonterminalRule : IRule<NonterminalKind>
        {
            public readonly RuleTable Def;

            public readonly NonterminalKind Kind;

            [MethodImpl(Inline)]
            public NonterminalRule(RuleTable def, NonterminalKind kind)
            {
                Def = def;
                Kind = kind;
            }

            public string Format()
                => XedFormatters.format(this);


            public override string ToString()
                => Format();

            RuleTable IRule.Def
                => Def;

            NonterminalKind IRule<NonterminalKind>.Kind
                => Kind;

            public static implicit operator NonterminalRule((RuleTable rule, NonterminalKind kind) src)
                => new NonterminalRule(src.rule, src.kind);

            public static NonterminalRule Empty => new NonterminalRule(RuleTable.Empty, 0);
        }
    }
}