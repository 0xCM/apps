//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
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
                => Def.Format();


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