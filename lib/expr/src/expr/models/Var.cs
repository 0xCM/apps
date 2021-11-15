//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines a variable
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct Var : IVar
    {
        public Label Name {get;}

        readonly Func<dynamic> Resolver;

        public Type ValueType {get;}

        [MethodImpl(Inline)]
        public Var(Label name, Type t, Func<dynamic> resolver)
        {
            Name = name;
            ValueType = t;
            Resolver = resolver;
        }

        [MethodImpl(Inline)]
        public BoundVar Bind()
            => new BoundVar(this, Resolver());

        [MethodImpl(Inline)]
        public Value<dynamic> Resolve()
            => new Value<dynamic>(Resolver());

        public string Format()
            => expr.format(this);

        public override string ToString()
            => Format();
    }
}