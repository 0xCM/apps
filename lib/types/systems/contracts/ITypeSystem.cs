//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypeSystem
    {
        Label Name {get;}

        ReadOnlySpan<TypeKind> Primitives {get;}
    }

    [Free]
    public interface ITypeSystem<K> : ITypeSystem
        where K : unmanaged
    {
        new ReadOnlySpan<TypeKind<K>> Primitives {get;}

        ReadOnlySpan<TypeKind> ITypeSystem.Primitives
            => Primitives.Map(types.untype);
    }
}