//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [DataWidth(8)]
        public readonly struct NontermCall
        {
            public readonly NonterminalKind Kind;

            [MethodImpl(Inline)]
            public NontermCall(NonterminalKind kind)
            {
                Kind = kind;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator NontermCall(NonterminalKind kind)
                => new NontermCall(kind);

            public static NontermCall Empty => default;
        }
    }
}