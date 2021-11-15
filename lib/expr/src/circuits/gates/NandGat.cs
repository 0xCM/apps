//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class NandGat<T> : BinaryGate<NandGat<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Nand;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => gates.nand(a,b);
    }
}