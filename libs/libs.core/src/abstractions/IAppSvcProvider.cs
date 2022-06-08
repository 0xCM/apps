//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IAppSvcProvider : ISvcProvider
    {
        IAppService Service(Type host, IWfRuntime wf);

        S Service<S>(IWfRuntime wf)
            where S : IAppService, new();

        S Service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : IAppService, new();
    }

    public interface IAppSvcProvider<T> : IAppSvcProvider, ISvcProvider<T>
        where T : IAppSvcProvider<T>, new()
    {

    }
}