//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppServices<T> : Services<T>, IAppSvcProvider<T>
        where T : AppServices<T>, new()
    {
        public IAppService Service(Type host, IWfRuntime wf)
                => (IAppService)Lookup.GetOrAdd(host, _ => {
                    var service = (IAppService)Activator.CreateInstance(host);
                    service.Init(wf);
                    return service;
                });

        public S Inject<S>(S svc)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(typeof(S), svc);

        public S Service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(typeof(S), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(typeof(S), _ => factory(wf));
   }
}