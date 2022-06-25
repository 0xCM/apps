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

        public ReadOnlySpan<Type> HostTypes
        {
            [MethodImpl(Inline)]
            get => _HostTypes.View;
        }

        public S Service<S>()
            where S : new()
                => (S)Lookup.GetOrAdd(svcid<S>(), new S());

        public S Service<S>(string name)
            where S : new()
                => (S)Lookup.GetOrAdd(svcid<S>(name), new S());

        public S Service<S>(string name, Func<S> f)
            => (S)Lookup.GetOrAdd(svcid<S>(name), f());
    }
}