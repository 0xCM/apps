//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokens;

    public sealed class AsmSigTokenSet //: TokenSet<AsmSigTokenSet,AsmSigTokenKind>
    {
        public static AsmSigTokenSet create()
            => new AsmSigTokenSet();

        readonly Index<AsmSigTokenKind,Index<Token>> _Tokens;

        readonly ConstLookup<Type,AsmSigTokenKind> _TypeKinds;

        public readonly uint KindCount;

        public readonly uint TokenCount;

        public readonly Symbols<AsmSigTokenKind> Kinds;

        public AsmSigTokenKind Kind(Type src)
            => _TypeKinds[src];

        public Index<Token> Tokens(Type src)
            => _Tokens[Kind(src)];

        AsmSigTokenSet()
        {
            Kinds = Symbols.index<AsmSigTokenKind>();
            KindCount = Kinds.Count;
            var types = typeof(AsmSigTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>();
            _TypeKinds = types.Select(t => (t, t.Tag<SigTokenKind>().Require().Kind)).ToDictionary();

            _Tokens = alloc<Index<Token>>(Kinds.Count);
            for(var i=0; i<Kinds.Count; i++)
                _Tokens[(AsmSigTokenKind)i] = sys.empty<Token>();

            var counter = 0u;
            for(var i=0; i<types.Length; i++)
            {
                var kind = _TypeKinds[skip(types,i)];
                _Tokens[kind] = Symbols.tokenize(skip(types,i));
                counter += _Tokens[kind].Count;
            }
            TokenCount = counter;
        }

        public string Name
            => "asm.sigs";

        public ReadOnlySpan<Type> Types()
            => _TypeKinds.Keys;

        public ConstLookup<Type,AsmSigTokenKind> TypeKinds()
            => _TypeKinds;
    }
}