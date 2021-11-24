//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class MuxGate<T> : TernaryGate<MuxGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Mux;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b, T c)
            => gates.mux(a,b,c);
    }
}