//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a variable
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Var<T> : IVar<T>
    {
        public Label Name {get;}

        readonly Func<T> Resolver;

        [MethodImpl(Inline)]
        public Var(Label name, Func<T> resolver)
        {
            Name = name;
            Resolver = resolver;
        }

        [MethodImpl(Inline)]
        public Value<T> Resolve()
            => Resolver();
        public string Format()
            => ExprFormatters.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Var(Var<T> src)
            => new Var(src.Name, typeof(T), () => src.Resolver());
    }
}