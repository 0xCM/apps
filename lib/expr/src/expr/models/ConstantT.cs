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
    /// Defines an invariant value
    /// </summary>
    public readonly struct Constant<T> : IConstExpr<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Constant(T value)
        {
            Value = value;
        }

        public string Format()
            => ExprFormatters.Constant<T>().Format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Constant<T>(T src)
            => new Constant<T>(src);
    }
}