//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ServiceCache]
    public abstract class AppServices<T> : IServiceProvider<T>
        where T : AppServices<T>, new()
    {
        public static T Instance = new();

        ConcurrentDictionary<Type,IAppService> Lookup = new();

        Index<Type> _HostTypes;

        protected AppServices()
        {
            _HostTypes = typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
        }

        public Assembly HostComponent => typeof(T).Assembly;

        public PartId PartId => HostComponent.Id();

        public ReadOnlySpan<Type> HostTypes
        {
            [MethodImpl(Inline)]
            get => _HostTypes.View;
        }

        public IAppService Service(Type host, IWfRuntime wf)
                => Lookup.GetOrAdd(host, _ => {
                    var service = (IAppService)Activator.CreateInstance(host);
                    service.Init(wf);
                    return service;
                });

        public S Service<S>(Func<S> f)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(typeof(S), f());

        public S Inject<S>(S svc)
            where S : IAppService, new()
                => (S)Lookup.GetOrAdd(typeof(S), svc);

        public S Injected<S>()
            where S : IAppService, new()
                => (S)Lookup[typeof(S)];

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