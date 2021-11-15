//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IRegOpClass : IAsmOpClass
    {

    }

    public interface IRegOpClass<T> : IAsmOpClass<T>
        where T : unmanaged, IRegOpClass<T>
    {
        RegClassCode RegClass {get;}
    }
}