//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmSigOp<K>
        where K : unmanaged
    {
        K Token {get;}
    }

    public interface IAsmSigOp<T,K> : IAsmSigOp<K>
        where T : unmanaged, IAsmSigOp<T,K>
        where K : unmanaged
    {

    }
}