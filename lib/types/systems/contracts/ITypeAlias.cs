//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITypeAlias : IDependency<TypeKind>
    {
        TypeKind AliasType {get;}

        TypeKind BaseType {get;}

        TypeKind IDependency<TypeKind>.Source
            => AliasType;

        TypeKind IDependency<TypeKind>.Target
            => BaseType;
    }

    public interface ITypeAlias<A,B> : ITypeAlias, IDependency<TypeKind<A>, TypeKind<B>>
        where A : unmanaged
        where B : unmanaged
    {
        new TypeKind<A> AliasType {get;}

        new TypeKind<B> BaseType {get;}

        TypeKind ITypeAlias.AliasType
            => AliasType;

        TypeKind ITypeAlias.BaseType
            => BaseType;

        TypeKind<A> IDependency<TypeKind<A>,TypeKind<B>>.Source
            => AliasType;

        TypeKind<B> IDependency<TypeKind<A>,TypeKind<B>>.Target
            => BaseType;
    }
}