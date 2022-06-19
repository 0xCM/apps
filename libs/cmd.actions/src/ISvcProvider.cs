//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISvcProvider
    {
        Assembly HostComponent {get;}

        PartId PartId {get;}

        ReadOnlySpan<Type> HostTypes {get;}

        S Service<S>();
    }

    public interface ISvcProvider<T> : ISvcProvider
        where T : ISvcProvider<T>, new()
    {
        Assembly ISvcProvider.HostComponent
            => typeof(T).Assembly;

        PartId ISvcProvider.PartId
            => HostComponent.Id();

        ReadOnlySpan<Type> ISvcProvider.HostTypes
            => typeof(T).DeclaredPublicInstanceMethods().Concrete().Select(x => x.ReturnType);
    }
}