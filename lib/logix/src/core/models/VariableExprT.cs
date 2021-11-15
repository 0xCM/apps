//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class VariableExpr<T> : IVarExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The name of the variable
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The value of the variable
        /// </summary>
        public ILogixExpr<T> Value {get; private set;}

        [MethodImpl(Inline)]
        public VariableExpr(string name, ILogixExpr<T> value)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Updates the variable's value
        /// </summary>
        /// <param name="value">The new value</param>
        [MethodImpl(Inline)]
        public void Set(ILogixExpr<T> value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public void Set(T value)
        {
            Value = new LiteralExpr<T>(value);
        }

        [MethodImpl(Inline)]
        public void Set(IExpr value)
            => Value = (ILogixExpr<T>)value;

        public string Format()
            => Format(false);

        public string Format(bool expand)
            => $"{Name}:{typeof(T).DisplayName()}" + (expand ? $" := {Value}" : string.Empty);

        public override string ToString()
            => Format();
    }
}