//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ServiceCache]
    public abstract class Services<T> : ISvcProvider<T>
        where T : Services<T>, new()
    {
        public static T Instance = new();

        protected ConcurrentDictionary<Type,IService> Lookup = new();

        Index<Type> _HostTypes;

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

        public IService Service(Type host)
                => Lookup.GetOrAdd(host, _ => (IService)Activator.CreateInstance(host));
        public S Service<S>()
            where S : IService, new()
                => (S)Lookup.GetOrAdd(typeof(S), new S());

        public S Service<S>(Func<S> f)
            where S : IService, new()
                => (S)Lookup.GetOrAdd(typeof(S), f());
    }
}