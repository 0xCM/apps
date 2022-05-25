//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IServiceCache
    {
        Assembly HostComponent {get;}

        PartId PartId {get;}

        ReadOnlySpan<Type> HostTypes {get;}

        IAppService Service(Type host, IWfRuntime wf);

        S Service<S>(IWfRuntime wf)
            where S : IAppService<S>, new();

        S Service<S>(IWfRuntime wf, Func<IWfRuntime,S> factory)
            where S : IAppService<S>, new();
    }

    public interface IServiceCache<T> : IServiceCache
        where T : IServiceCache<T>, new()
    {
        Assembly IServiceCache.HostComponent
            => typeof(T).Assembly;

        PartId IServiceCache.PartId
            => HostComponent.Id();

        ReadOnlySpan<Type> IServiceCache.HostTypes
            => typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
    }
}