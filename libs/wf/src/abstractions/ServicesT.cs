//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ServiceCache]
    public abstract class Services<T>
        where T : Services<T>, new()
    {
        public static T Instance = new();

        [MethodImpl(Inline)]
        public static S inject<S>(S svc)
            => (S)Instance.Lookup.GetOrAdd(svcid<S>(), svc);

        [MethodImpl(Inline)]
        public static S injected<S>()
            => (S)Instance.Lookup[svcid<S>()];

        [MethodImpl(Inline)]
        public static S service<S>()
            where S : new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(), new S());

        [MethodImpl(Inline)]
        public S service<S>(string name)
            where S : new()
                => (S)Instance.Lookup.GetOrAdd(svcid<S>(name), new S());

        [MethodImpl(Inline)]
        public S service<S>(string name, Func<S> f)
            => (S)Instance.Lookup.GetOrAdd(svcid<S>(name), f());

        protected ConcurrentDictionary<string,object> Lookup = new();

        Index<Type> _HostTypes;

        protected static string svcid(Type host)
            => host.DisplayName();

        protected static string svcid(Type host, string name)
            => svcid(host) + $".{name}";

        protected static string svcid<S>()
            => svcid(typeof(S));

        protected static string svcid<S>(string name)
            => svcid(typeof(S), name);

        protected Services()
        {
            _HostTypes = typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
        }

        public Assembly HostComponent => typeof(T).Assembly;

        public PartId PartId => HostComponent.Id();


        public S Inject<S>(S svc)
            => inject(svc);

        public S Injected<S>()
            => injected<S>();

        public S Service<S>()
            where S : new()
                => service<S>();

        public S Service<S>(string name)
            where S : new()
                => service<S>(name);

        public S Service<S>(string name, Func<S> f)
            => service(name,f);

        public ReadOnlySpan<Type> HostTypes
        {
            [MethodImpl(Inline)]
            get => _HostTypes.View;
        }
    }
}