//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IImmOpClass<T> : IAsmOpClass<T>
        where T : unmanaged, IImmOpClass<T>
    {

    }
}