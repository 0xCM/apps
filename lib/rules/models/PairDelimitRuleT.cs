//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PairDelimitRule<T>
        where T : IEquatable<T>
    {
        public DelimitRule<T> Left {get;}

        public DelimitRule<T> Right {get;}

        [MethodImpl(Inline)]
        public PairDelimitRule(DelimitRule<T> left, DelimitRule<T> right)
        {
            Left = left;
            Right = right;
        }

        [MethodImpl(Inline)]
        public bool Test(T a0, T a1)
            => Left.Test(a0) && Right.Test(a1);

        [MethodImpl(Inline)]
        public static implicit operator PairDelimitRule<T>((T left, T right) src)
            => new PairDelimitRule<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator PairDelimitRule<T>((DelimitRule<T> left, DelimitRule<T> right) src)
            => new PairDelimitRule<T>(src.left, src.right);
    }
}