//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    using Expr;

    /// <summary>
    /// Binds a variable to a value
    /// </summary>
    public readonly struct BoundVar : IBinding
    {
        public readonly Var Var;

        public Value<dynamic> Value {get;}

        [MethodImpl(Inline)]
        public BoundVar(Var var, Value<dynamic> val)
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
        public static implicit operator BoundVar((Var var, Value<dynamic> val) src)
            => new BoundVar(src.var, src.val);
    }
}