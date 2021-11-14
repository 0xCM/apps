//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmCheck : ITextual
    {
        bit Passed {get;}
    }
    public interface IAsmCheck<C,S,T> : IAsmCheck
        where C : struct, IAsmCheck<C,S,T>
    {
        S Input {get;}

        T Expect {get;}

        T Actual {get;}
    }
}