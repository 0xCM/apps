//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmOpCodeToken
    {
        AsmOcTokenKind Kind {get;}

        byte Value {get;}
    }

    public interface IAsmOpCodeToken<V> : IAsmOpCodeToken
        where V : unmanaged
    {
        new V Value {get;}

        byte IAsmOpCodeToken.Value
            => core.bw8(Value);
    }

    public interface IAsmOpCodeToken<T,V> : IAsmOpCodeToken
        where V : unmanaged
        where T : unmanaged, IAsmOpCodeToken<T,V>
    {
        new V Value {get;}

        byte IAsmOpCodeToken.Value
            => core.bw8(Value);
    }
}