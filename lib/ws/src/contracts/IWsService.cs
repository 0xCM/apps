//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsService : IService
    {
        IWorkspace Ws {get;}
    }

    public interface IWsService<T> : IWsService
        where T : IWsService<T>, new()
    {

    }
}