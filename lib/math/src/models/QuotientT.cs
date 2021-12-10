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
    /// Defines a datatype that represents a rational number
    /// </summary>
    [DataType("quotient<{T}>")]
    public struct Quotient<T> : IRational<Quotient<T>,T>
    {
        public T Over {get;}

        public T Under {get;}

        [MethodImpl(Inline)]
        public Quotient(T over, T under)
        {
            Over = over;
            Under = under;
        }

        [MethodImpl(Inline)]
        public string Format()
            => string.Format($"{Over}/{Under}");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Quotient<T>((T over, T under) src)
            => new Quotient<T>(src.over, src.under);

        [MethodImpl(Inline)]
        public static implicit operator Quotient<T>(Pair<T> src)
            => new Quotient<T>(src.Left, src.Right);

        public static Quotient<T> Undefined
            => default;

        public static Quotient<T> Zero
            => (default(T), Numeric.force<T>(1));
    }
}