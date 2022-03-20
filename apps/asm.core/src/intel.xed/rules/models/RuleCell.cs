//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCell
        {
            public readonly bool Premise;

            public readonly FieldKind Field;

            public readonly string Data;

            public readonly bool IsLiteral;

            [MethodImpl(Inline)]
            public RuleCell(bool premise, string data)
            {
                Premise = premise;
                Field = XedFields.kind(data);
                Data = text.ifempty(data,EmptyString);
                IsLiteral = Field == 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(Data);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsNonterminal
            {
                [MethodImpl(Inline)]
                get => XedParsers.IsNonterminal(Data);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();
        }
    }
}