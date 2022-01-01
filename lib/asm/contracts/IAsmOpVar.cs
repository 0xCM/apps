//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpVar<T> : IAsmOp, IVar<T>
        where T : struct, IAsmOp
    {
        void Set(T value);
    }

    public interface IAsmOpVar<F,T> : IAsmOpVar<T>
        where F : IAsmOpVar<F,T>
        where T : struct, IAsmOp
    {
        new F Set(T value);

        void IAsmOpVar<T>.Set(T value)
            => Set(value);
    }
}