//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class AndGate<T> : BinaryGate<AndGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.And;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => gates.and(a,b);
    }
}