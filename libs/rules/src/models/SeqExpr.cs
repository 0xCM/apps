//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        public class SeqExpr : RuleExpr<Index<IExprDeprecated>>, ISeqExpr<IExprDeprecated>
        {
            public SeqExpr(params IExprDeprecated[] terms)
                : base(terms)
            {

            }

            public uint N
            {
                [MethodImpl(Inline)]
                get => Content.Count;
            }

            public ReadOnlySpan<IExprDeprecated> Terms
                => Content;

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

            public static implicit operator SeqExpr(IExprDeprecated[] src)
                => new SeqExpr(src);
        }
    }
}