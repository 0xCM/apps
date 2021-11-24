//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class OrGate<T> : BinaryGate<OrGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Or;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => gates.or(a,b);
    }
}