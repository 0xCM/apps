//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr.Circuits
{
    public abstract class Gate<F,T>
        where F : Gate<F,T>, new()
        where T : unmanaged
    {
        public abstract GateKind Kind {get;}
    }

    public abstract class UnaryGate<F,T> : Gate<F,T>
        where F : UnaryGate<F,T>,new()
        where T : unmanaged
    {
        public abstract T Flow(T a);
    }

    public abstract class BinaryGate<F,T> : Gate<F,T>
        where F : BinaryGate<F,T>,new()
        where T : unmanaged
    {
        public abstract T Flow(T a, T b);
    }

    public abstract class TernaryGate<F,T> : Gate<F,T>
        where F : TernaryGate<F,T>,new()
        where T : unmanaged
    {
        public abstract T Flow(T a, T b, T c);
    }

}