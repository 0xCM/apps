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
    /// Represents the consecutive occurrence of two values within a sequence
    /// </summary>
    public class AdjacentRule<T> : RuleExpr<Pair<T>>
    {
        [MethodImpl(Inline)]
        public AdjacentRule(T a, T b)
            : base((a,b))
        {

        }

        public override string Format()
            => string.Format(RP.Adjacent2,Content.Left, Content.Right);

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>((T left, T right) src)
            => new AdjacentRule<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>(Pair<T> src)
            => new AdjacentRule<T>(src.Left, src.Right);
    }
}