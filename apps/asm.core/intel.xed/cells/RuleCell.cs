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
            public readonly bool IsPremise;

            public readonly bool IsLiteral;

            public readonly bool IsOperator;

            public readonly FieldKind Field;

            public readonly string Data;

            [MethodImpl(Inline)]
            public RuleCell(bool premise, string data)
            {
                IsPremise = premise;
                Field = XedFields.kind(data);
                Data = text.ifempty(data,EmptyString);
                IsLiteral = Field == 0;
                IsOperator = false;
            }

            [MethodImpl(Inline)]
            public RuleCell(bool premise, RuleOperator data)
            {
                IsPremise = premise;
                Field = FieldKind.INVALID;
                Data = data.Format();
                IsLiteral = false;
                IsOperator = true;
            }

            public bool IsExpr
                => XedParsers.IsFieldExpr(Data);

            public RuleOperator Operator
            {
                get
                {
                    XedParsers.parse(Data, out OperatorKind dst);
                    return dst;
                }
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(Data);
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();
        }
    }
}