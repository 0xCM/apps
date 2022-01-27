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
    public class AdjacentRule<T> : Rule
    {
        public T A {get;}

        public T B {get;}

        [MethodImpl(Inline)]
        public AdjacentRule(T a, T b)
        {
            A = a;
            B = b;
        }

        public override string Format()
            => string.Format(RP.Adjacent2,A, B);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>((T left, T right) src)
            => new AdjacentRule<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator AdjacentRule<T>(Pair<T> src)
            => new AdjacentRule<T>(src.Left, src.Right);
    }
}