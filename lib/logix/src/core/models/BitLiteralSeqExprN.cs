//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a natural-length sequence of literal bit values
    /// </summary>
    public readonly struct LiteralLogicSeqExpr<N> : ILiteralLogicSeqExpr
        where N : unmanaged, ITypeNat
    {
        public Index<bit> Terms {get;}

        [MethodImpl(Inline)]
        public LiteralLogicSeqExpr(bit[] terms)
            => Terms = terms;

        public bit this[int index]
        {
            [MethodImpl(Inline)]
            get => Terms[index];

            [MethodImpl(Inline)]
            set => Terms[index] = value;
        }

        public int Length
            => Terms.Length;

        public LogicExprKind ExprKind
            => LogicExprKind.Literal;

        public string Format()
            => BitRender.gformat(Terms);

        public override string ToString()
            => Format();
    }
}