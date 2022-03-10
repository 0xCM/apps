//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataType(XedNames.nonterminal)]
        public struct Nonterminal : IEnumCover<NonterminalKind>
        {
            public NonterminalKind Value {get;set;}

            [MethodImpl(Inline)]
            public Nonterminal(NonterminalKind src)
            {
                Value = src;
            }

            public string Format()
                => XedRender.format(Value);

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