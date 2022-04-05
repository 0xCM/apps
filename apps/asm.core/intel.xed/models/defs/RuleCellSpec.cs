//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleCellSpec
        {
            public readonly bool IsPremise;

            public readonly bool IsLiteral;

            public readonly bool IsOperator;

            public readonly FieldKind Field;

            public readonly RuleCellKind Kind;

            public readonly RuleOperator Operator;

            public readonly string Data;

            [MethodImpl(Inline)]
            public RuleCellSpec(bool premise, RuleCellKind kind, string data)
            {
                Require.invariant(data.Length < 48);
                IsPremise = premise;
                Field = XedFields.kind(data);
                Data = text.ifempty(data,EmptyString);
                IsLiteral = Field == 0;
                IsOperator = false;
                Kind = kind;
                XedParsers.parse(Data, out Operator);
            }

            public bool IsExpr
                => RuleParser.IsFieldExpr(Data);

            public RuleCellExpr Expr()
                => RuleParser.expr(Data);

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(Data);
            }

            public string Format()
                => Data;

            public override string ToString()
                => Format();
        }
    }
}