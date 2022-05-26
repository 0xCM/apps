//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INativeFunction : IAddressable
    {
        string Name {get;}

        NativeModule Source {get;}
    }

    [Free]
    public interface INativeFunction<D> : INativeFunction
        where D : Delegate
    {
        D Delegate {get;}
    }
}