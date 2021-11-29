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
    /// Defines a datatype that represents a discrete percentage
    /// </summary>
    public struct Percent<T> : ITextual
        where T : unmanaged
    {
        public Rational<T> Value;

        public static Percent<T> Zero
            => Rational<T>.Zero;

        [MethodImpl(Inline)]
        public Percent(T over, T under)
            => Value = (over,under);

        [MethodImpl(Inline)]
        public Percent(Rational<T> src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Percent<T>(Rational<T> src)
            => new Percent<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator Percent<T>(Pair<T> src)
            => new Percent<T>(src.Left, src.Right);
    }
}