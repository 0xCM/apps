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

        ReadOnlySpan<TypeKind> Kinds {get;}
    }

    [Free]
    public interface ITypeSystem<K> : ITypeSystem
        where K : unmanaged
    {
        new ReadOnlySpan<TypeKind<K>> Kinds {get;}

        ReadOnlySpan<TypeKind> ITypeSystem.Kinds
            => Kinds.Map(types.untype);
    }
}