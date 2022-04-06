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
        public struct RuleCellType
        {
            public FieldKind Field;

            public RuleCellKind Kind;

            public bool IsNumeric
            {
                [MethodImpl(Inline)]
                get => Kind == CK.HexLiteral || Kind == CK.BinaryLiteral || Kind == CK.IntLiteral;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Kind == CK.Branch || Kind == CK.Null || Kind == CK.Error || Kind == CK.Wildcard || Kind == CK.Default;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Kind == CK.NontermCall || Kind == CK.NontermExpr;
            }

            public RuleOperator Operator;

            public asci16 DataType;

            public asci16 EffectiveType;

            public static RuleCellType Empty => default;

            public string Format()
                => (IsNumeric || IsKeyword || Kind == CK.BfSpec)
                ? XedRender.format(Kind)
                : DataType == EffectiveType
                ? DataType.Format()
                : string.Format("{0}:{1}", EffectiveType, DataType);

            public override string ToString()
                => Format();
        }
    }
}