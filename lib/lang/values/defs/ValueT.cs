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
    /// A terminal
    /// </summary>
    public readonly struct Value<T> : IExpr
    {
        public T Content {get;}

        [MethodImpl(Inline)]
        public Value(T value)
        {
            Content = value;
        }

        public string Format()
            => Content.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Value<T>(T src)
            => new Value<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Value<T> src)
            => src.Content;
    }
}