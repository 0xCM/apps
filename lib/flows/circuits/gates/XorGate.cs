//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class XorGate<T> : BinaryGate<XorGate<T>,T>
        where T : unmanaged
    {
        public override GateKind Kind
            => GateKind.Xor;

        [MethodImpl(Inline)]
        public override T Flow(T a, T b)
            => gates.xor(a,b);
    }
}