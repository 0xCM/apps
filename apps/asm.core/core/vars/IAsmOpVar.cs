//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpVar<T> : IAsmOp, IVar<T>
        where T : IAsmOp
    {
        void Update(T value);
    }

    public interface IAsmOpVar<F,T> : IAsmOpVar<T>
        where T : struct, IAsmOp
    {

    }
}