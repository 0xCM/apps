//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class NotGate<T> : UnaryGate<NotGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Not;

        [MethodImpl(Inline)]
        public override T Flow(T a)
            => gates.not(a);
    }
}