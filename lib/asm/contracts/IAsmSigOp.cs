//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmSigOp
    {
        AsmSigOpKind OpKind => AsmSigOpKind.None;

        byte Value {get;}
    }

    public interface IAsmSigOp<K> : IAsmSigOp
        where K : unmanaged
    {
        K Token {get;}

        byte IAsmSigOp.Value
            => core.bw8(Token);
    }

    public interface IAsmSigOp<T,K> : IAsmSigOp<K>
        where T : unmanaged, IAsmSigOp<T,K>
        where K : unmanaged
    {

    }
}