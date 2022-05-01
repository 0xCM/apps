//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct CellInfo
        {
            public readonly CellTypeInfo Type;

            public readonly LogicClass Logic;

            public readonly string Data;

            public CellInfo(in CellTypeInfo type, LogicClass logic, string data)
            {
                Type = type;
                Data = text.ifempty(data, EmptyString);
                Logic = logic;
            }

            [MethodImpl(Inline)]
            public CellInfo(RuleOperator op)
            {
                Type = CellTypeInfo.@operator(op);
                Data = EmptyString;
                Logic = LogicKind.Operator;
            }

            public RuleCellKind Kind
            {
                [MethodImpl(Inline)]
                get => Type.Class.Kind;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Keyword;
            }

            public bool IsBinLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.BitLiteral;
            }

            public bool IsHexLit
            {
                [MethodImpl(Inline)]
                get => Kind == CK.HexLiteral;
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Type.Field;
            }

            public readonly RuleOperator Operator
            {
                [MethodImpl(Inline)]
                get => Type.Operator;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => text.empty(Data) && Operator.IsEmpty && Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => !IsEmpty;
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => Field != 0 && Operator.IsNonEmpty;
            }

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => XedParsers.IsSeg(Data);
            }

            public bool IsNontermCall
            {
                [MethodImpl(Inline)]
                get => XedParsers.IsNonterm(Data);
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();
        }
    }
}