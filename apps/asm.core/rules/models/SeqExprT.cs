//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SeqRule<T> : IndexRuleExpr<SeqRule<T>,T>, ISeqRule
        where T : IRuleExpr
    {
        public SeqRule(params T[] terms)
            : base(terms)
        {
        }

        public new Index<IRuleExpr> Terms
            => Content.Map(x => (IRuleExpr)x);
        public override string Format()
            => text.embrace(Content.Delimit().Format());

        [MethodImpl(Inline)]
        public static implicit operator SeqRule<T>(T[] src)
            => new SeqRule<T>(src);
    }
}