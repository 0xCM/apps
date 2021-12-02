//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpVar
    {
        AsmOperand Resolve(uint seq);
    }

    public interface IAsmOpVar<T> : IAsmOpVar
        where T : IAsmOp
    {
        new T Resolve(uint seq);
    }
}