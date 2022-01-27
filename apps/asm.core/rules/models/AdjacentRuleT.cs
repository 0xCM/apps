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
    public readonly struct AdjacentRule<T> : IExpr
    {
        public readonly T A;

        public readonly T B;

        [MethodImpl(Inline)]
        public AdjacentRule(T a, T b)
        {
            A = a;
            B = b;
        }

        public string Format()
            => Rules.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>((T left, T right) src)
            => new AdjacentRule<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>(Pair<T> src)
            => new AdjacentRule<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule(AdjacentRule<T> src)
            => new AdjacentRule(src.A, src.B);
    }
}