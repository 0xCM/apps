//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    [Free]
    public interface ITypeIdentityProvider : IIdentityProvider<Type,TypeIdentity>
    {
        IEnumerable<Type> Identifiable
            => core.stream<Type>();

        bool CanIdentify(Type src)
            => Identifiable.Contains(src);

        IIdentified IIdentityProvider<Type>.Identify(Type src)
            => Identify(src);

        IdentityTargetKind IIdentityProvider.ProviderKind
            => IdentityTargetKind.Type;
    }

    /// <summary>
    /// Characterizes a type identity provider than can define an identity predicated solely on a parametric type
    /// </summary>
    /// <typeparam name="S">The type for which identity will be defined</typeparam>
    [Free]
    public interface ITypeIdentityProvider<S> : ITypeIdentityProvider
    {
        TypeIdentity Identity();

        IEnumerable<Type> ITypeIdentityProvider.Identifiable
            => core.array(typeof(S));

        TypeIdentity IIdentityProvider<Type,TypeIdentity>.Identify(Type src)
            => Identity();
    }

    [Free]
    public interface ITypeIdentityProvider<F,T> : ITypeIdentityProvider
        where F : struct, ITypeIdentityProvider<F,T>
        where T : struct, IIdentifiedType
    {
        new T Identify(Type src);

        TypeIdentity IIdentityProvider<Type,TypeIdentity>.Identify(Type src)
            => new TypeIdentity(Identify(src).IdentityText);
    }
}