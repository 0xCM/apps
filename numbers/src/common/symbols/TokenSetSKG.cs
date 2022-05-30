//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class TokenSet<S,K,G>
        where K : unmanaged, Enum
        where S : TokenSet<S,K,G>, new()
        where G : ITokenGroup<G,K>, new()
    {
        public static S create()
            => new S();

        public readonly G Group = new();

        protected TokenSet()
        {
            // Kinds = Symbols.index<K>();
            // KindCount = Kinds.Count;
            // var types = typeof(G).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();

            // _TypeKinds = types.Select(t => (t, t.Tag<TokenKindAttribute<K>>().Require().Kind)).ToDictionary();

            // _Tokens = alloc<Index<Token>>(Kinds.Count);
            // for(var i=0u; i<Kinds.Count; i++)
            //     _Tokens[@as<K>(i)] = sys.empty<Token>();


            // var counter = 0u;
            // for(var i=0; i<types.Length; i++)
            // {
            //     var kind = _TypeKinds[skip(types,i)];
            //     _Tokens[kind] = Symbols.tokenize(skip(types,i));
            //     counter += _Tokens[kind].Count;
            // }
            // TokenCount = counter;
        }

        public uint TokenCount
        {
            [MethodImpl(Inline)]
            get => Group.TokenCount;
        }

        public ReadOnlySpan<Type> TokenTypes
        {
            [MethodImpl(Inline)]
            get => Group.TokenTypes;
        }

        [MethodImpl(Inline)]
        public K Kind(Type src)
            => Group.Kind(src);

        [MethodImpl(Inline)]
        public Index<Token> Tokens(Type src)
            => Group.Tokens(src);

        public ConstLookup<Type,K> TypeKinds
        {
            [MethodImpl(Inline)]
            get => Group.TypeKinds;
        }
    }
}