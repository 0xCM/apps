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
            public readonly FieldKind Field;

            public readonly string Data;

            public readonly bool IsLiteral;

            [MethodImpl(Inline)]
            public RuleCell(FieldKind field, string data)
            {
                Field = field;
                Data = text.ifempty(data,EmptyString);
                IsLiteral = field == 0;
            }

            [MethodImpl(Inline)]
            public RuleCell(string data)
            {
                Field = 0;
                Data = data;
                IsLiteral = true;
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
                => text.ifempty(Data,EmptyString);

            public override string ToString()
                => Format();
        }
    }
}