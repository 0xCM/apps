//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmVarResolver<T>
        where T : IAsmOp
    {
        T Resolve(byte index, uint seq);
    }
}