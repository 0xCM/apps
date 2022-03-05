//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        public struct RuleOpSpec
        {
            public RuleOpName Name;

            public RuleOpKind Kind;

            public Index<string> Properties;

            public Index<OperandAttrib> Attributes;

            public @string Expression;

            public @string Refinement;

            public string Format()
                => Properties.Delimit(Chars.Colon).Format();

            public override string ToString()
                => Format();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name != 0;
            }
        }
    }
}