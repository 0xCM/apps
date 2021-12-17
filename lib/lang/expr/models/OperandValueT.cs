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
    public readonly struct OperandValue<T>
    {
        public string Name {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public OperandValue(string name, T value)
        {
            Name = name;
            Content = value;
        }

        public string Format()
            => string.Format("{0}:{1}", Name, Content);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OperandValue(OperandValue<T> src)
            => new OperandValue(src.Name, src.Content);

        [MethodImpl(Inline)]
        public static implicit operator OperandValue<T>((string name, T value) src)
            => new OperandValue<T>(src.name, src.value);
    }
}