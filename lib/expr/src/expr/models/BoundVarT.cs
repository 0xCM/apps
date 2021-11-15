//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Expr;

    /// <summary>
    /// Binds a variable to a value
    /// </summary>
    public readonly struct BoundVar<T> : IBinding<T>
    {
        public readonly Var Var;

        public Value<T> Value {get;}

        [MethodImpl(Inline)]
        public BoundVar(Var var, T val)
        {
            Var = var;
            Value = val;
        }

        public Label Name
        {
            [MethodImpl(Inline)]
            get => Var.Name;
        }

        public string Format()
            => expr.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BoundVar<T>((Var var, T val) src)
            => new BoundVar<T>(src.var, src.val);

        [MethodImpl(Inline)]
        public static implicit operator BoundVar(BoundVar<T> src)
            => new BoundVar(src.Var, src.Value);

        [MethodImpl(Inline)]
        public static implicit operator T(BoundVar<T> src)
            => src.Value.Content;
    }
}