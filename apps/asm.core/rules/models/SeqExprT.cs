//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class SeqExpr<T> : RuleExpr<Index<T>>, ISeqExpr<T>
        where T : IRuleExpr
    {
        public SeqExpr(params T[] terms)
            : base(terms)
        {
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => Content.Count;
        }

        public ReadOnlySpan<T> Terms
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsNonEmpty;
        }

         public override string Format()
            => text.embrace(Content.Delimit().Format());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SeqExpr<T>(T[] src)
            => new SeqExpr<T>(src);
    }
}