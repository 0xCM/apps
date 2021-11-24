//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines an operand value of parametric type
    /// </summary>
    public readonly struct Operand<T>
    {
        public Label Name {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public Operand(Label name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Operand(Operand<T> src)
            => new Operand(src.Name, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Operand<T>((Label name, T value) src)
            => new Operand<T>(src.name, src.value);
    }
}