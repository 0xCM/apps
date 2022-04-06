//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.CellRole;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct CellType
        {
            public FieldKind Field;

            public CellRole Role;

            public bool IsNumeric
            {
                [MethodImpl(Inline)]
                get => Role == CK.HexLiteral || Role == CK.BinaryLiteral || Role == CK.IntLiteral;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Role == CK.Branch || Role == CK.Null || Role == CK.Error || Role == CK.Wildcard || Role == CK.Default;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Role == CK.NontermCall || Role == CK.NontermExpr;
            }

            public RuleOperator Operator;

            public asci16 DataType;

            public asci16 EffectiveType;

            public static CellType Empty => default;

            public string Format()
                => (IsNumeric || IsKeyword || Role == CK.BfSpec)
                ? XedRender.format(Role)
                : DataType == EffectiveType
                ? DataType.Format()
                : string.Format("{0}:{1}", EffectiveType, DataType);

            public override string ToString()
                => Format();
        }
    }
}