//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface IAsmOpCode
    {
        ReadOnlySpan<AsmOcToken> Tokens {get;}
    }

    public interface IAsmOpCode<T> : IAsmOpCode
        where  T : IAsmOpCode<T>
    {

    }

}