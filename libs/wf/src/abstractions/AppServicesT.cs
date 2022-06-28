//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppServices<T> : Services<T>
        where T : AppServices<T>, new()
    {
        public static S service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public static S service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(name), _ => {
                    var service = new S();
                    service.Init(wf);
                    return service;
                });

        public static IAppService service(IWfRuntime wf, Type host, string name)
                => (IAppService)Instance.Lookup.GetOrAdd(svcid(host, name), _ => {
                    var service = (IAppService)Activator.CreateInstance(host);
                    service.Init(wf);
                    return service;
                });

        public static S service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(name), _ => factory(wf));

        public IAppService Service(IWfRuntime wf, Type host, string name)
            => service(wf,host,name);

        public S Service<S>(IWfRuntime wf, string name)
            where S : IAppService, new()
                => service<S>(wf, name);

        public S Service<S>(IWfRuntime wf)
            where S : IAppService, new()
                => service<S>(wf);

        public S Service<S>(IWfRuntime wf, string name, Func<IWfRuntime,S> factory)
            where S : IAppService, new()
                => service(wf,name,factory);
   }
}