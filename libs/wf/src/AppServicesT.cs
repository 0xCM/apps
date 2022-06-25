//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppServices<T> : Services<T>
        where T : AppServices<T>, new()
    {
        public IAppService Service(IWfRuntime wf, Type host, string name)
                => (IAppService)Lookup.GetOrAdd(svcid(host, name), _ => {
                    var service = (IAppService)Activator.CreateInstance(host);
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(svcid<S>(name), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(svcid<S>(), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(svcid<S>(name), _ => factory(wf));
   }
}