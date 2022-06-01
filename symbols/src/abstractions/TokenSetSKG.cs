//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TokenSet<S,K,G> // : ITokenSet<S,K>
        where K : unmanaged, Enum
        where S : TokenSet<S,K,G>, new()
        where G : ITokenGroup<G,K>, new()
    {
        public static S create()
            => new S();

        //public readonly G Group = new();

        // public Symbols<K> Kinds
        //     => Group.Kinds;

        // public uint TokenCount
        // {
        //     [MethodImpl(Inline)]
        //     get => Group.TokenCount;
        // }

        // public uint KindCount
        // {
        //     [MethodImpl(Inline)]
        //     get => Group.KindCount;
        // }

        // public ReadOnlySpan<Type> TokenTypes
        // {
        //     [MethodImpl(Inline)]
        //     get => Group.TokenTypes;
        // }

        // [MethodImpl(Inline)]
        // public K Kind(Type src)
        //     => Group.Kind(src);

        // [MethodImpl(Inline)]
        // public Index<Token> Tokens(Type src)
        //     => Group.Tokens(src);

        // public ConstLookup<Type,K> TypeKinds
        // {
        //     [MethodImpl(Inline)]
        //     get => Group.TypeKinds;
        // }
    }
}