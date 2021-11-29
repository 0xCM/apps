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
    /// Defines a ratio between two values, a measure that indicates how many times the first number contains the second
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Ratio</remarks>
    public readonly struct Ratio<T>
        where T : unmanaged
    {
        /// <summary>
        /// The left value
        /// </summary>
        public T A {get;}

        /// <summary>
        /// The right value
        /// </summary>
        public T B {get;}

        [MethodImpl(Inline)]
        public Ratio(in T a, in T b)
        {
            A = a;
            B = b;
        }

        public string Format()
            => $"{A}:{B}";

        [MethodImpl(Inline)]
        public static implicit operator (T A, T B)(Ratio<T> src)
            => (src.A, src.B);

        [MethodImpl(Inline)]
        public static implicit operator Ratio<T>((T A, T B) src)
            => new Ratio<T>(src.A, src.B);
    }
}