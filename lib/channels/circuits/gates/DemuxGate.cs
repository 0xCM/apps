//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class DemuxGate<T> : Gate<DemuxGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Nand;

        [MethodImpl(Inline)]
        public Pair<T> Flow(T a, T b)
            => gates.demux(a,b);
    }
}