//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IServiceProvider
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

    public interface IServiceProvider<T> : IServiceProvider
        where T : IServiceProvider<T>, new()
    {
        Assembly IServiceProvider.HostComponent
            => typeof(T).Assembly;

        PartId IServiceProvider.PartId
            => HostComponent.Id();

        ReadOnlySpan<Type> IServiceProvider.HostTypes
            => typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
    }
}