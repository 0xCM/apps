//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ServiceCache<T> : IServiceCache
        where T : ServiceCache<T>, new()
    {
        ConcurrentDictionary<Type,IService> Lookup = new();

        public S Service<S>(IWfRuntime wf)
            where S : AppService<S>, new()
                => (S)Lookup.GetOrAdd(typeof(S), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : AppService<S>, new()
                => (S)Lookup.GetOrAdd(typeof(S), _ => factory(wf));
    }
}