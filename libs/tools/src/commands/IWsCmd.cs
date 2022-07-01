//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsCmd<C> : ICmd<C>
        where C : unmanaged, IWsCmd<C>
    {

    }
}