//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SeqExpr<T> : RuleExpr<SeqExpr<T>,T>, ISeqExpr<T>
        where T : IRuleExpr
    {
        public SeqExpr(params T[] terms)
            : base(terms)
        {
        }

        ReadOnlySpan<T> ISeqExpr<T>.Terms
            => Terms;

        public override string Format()
            => text.embrace(Content.Delimit().Format());

        [MethodImpl(Inline)]
        public static implicit operator SeqExpr<T>(T[] src)
            => new SeqExpr<T>(src);
    }
}