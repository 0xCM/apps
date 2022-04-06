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
        public readonly struct CellSpec
        {
            public readonly bool IsPremise;

            public readonly bool IsLiteral;

            public readonly bool IsOperator;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly string Data;

            [MethodImpl(Inline)]
            public CellSpec(bool premise, string data)
            {
                Require.invariant(data.Length < 48);
                IsPremise = premise;
                Field = XedFields.kind(data);
                Data = text.ifempty(data,EmptyString);
                IsLiteral = Field == 0;
                IsOperator = false;
                CellParser.parse(Data, out Operator);
            }

            public CellDef Expr()
                => CellParser.expr(Data);

            public CellRole Role()
                => CellParser.role(Data);

            public CellType CellType()
                => CellParser.celltype(this);

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