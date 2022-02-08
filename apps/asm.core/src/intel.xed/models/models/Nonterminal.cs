//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-nonterminal-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataType(Names.nonterminal)]
        public struct Nonterminal : IEnumCover<NonterminalKind>
        {
            public NonterminalKind Value {get;set;}

            [MethodImpl(Inline)]
            public Nonterminal(NonterminalKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(EnumCover<NonterminalKind> src)
                => new Nonterminal(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator Nonterminal(NonterminalKind src)
                => new Nonterminal(src);

            [MethodImpl(Inline)]
            public static implicit operator NonterminalKind(Nonterminal src)
                => src.Value;
        }
    }
}