//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITokenGroup
    {
        string GroupName {get;}

        uint KindCount {get;}

        uint TokenCount {get;}

        Type KindType {get;}

        Type GroupType {get;}

        ReadOnlySpan<Type> TokenTypes {get;}
    }

    public interface ITokenGroup<G> : ITokenGroup
        where G : ITokenGroup<G>, new()
    {
        Type ITokenGroup.GroupType
            => typeof(G);
    }

    public interface ITokenGroup<G,K> : ITokenGroup<G>
        where G : ITokenGroup<G,K>, new()
        where K : unmanaged, Enum
    {
        Symbols<K> Kinds {get;}

        ConstLookup<Type,K> TypeKinds {get;}

        Index<K,Index<Token>> KindedTokens {get;}

        Index<Token> Tokens(Type src)
            => KindedTokens[Kind(src)];

        K Kind(Type src)
            => TypeKinds[src];

        Type ITokenGroup.KindType
            => typeof(K);

        ReadOnlySpan<Type> ITokenGroup.TokenTypes
            => TypeKinds.Keys;

        uint ITokenGroup.KindCount
            => Kinds.Count;

        uint ITokenGroup.TokenCount
            => KindedTokens.Count;
    }
}