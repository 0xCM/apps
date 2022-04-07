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
        public struct CellType
        {
            public static CellType @operator(RuleOperator op)
            {
                var dst = new CellType();
                dst.Field = 0;
                dst.Class = RuleCellKind.Operator;
                dst.Operator = op;
                dst.DataType = asci16.Null;
                dst.EffectiveType = asci16.Null;
                return dst;
            }

            public FieldKind Field;

            public CellClass Class;

            public RuleOperator Operator;

            public asci16 DataType;

            public asci16 EffectiveType;

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsNonEmpty;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Class.IsEmpty;
            }

            public bool IsNumber
            {
                [MethodImpl(Inline)]
                get => Class.IsNumber;
            }

            public bool IsKeyword
            {
                [MethodImpl(Inline)]
                get => Class.IsKeyword;
            }

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Class.IsNonterm;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Class.IsOperator;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Class.IsLiteral;
            }

            public bool IsValue
            {
                [MethodImpl(Inline)]
                get => Class.IsValue;
            }

            public bool IsChar
            {
                [MethodImpl(Inline)]
                get => Class.IsChar;
            }

            public bool IsString
            {
                [MethodImpl(Inline)]
                get => Class.IsString;
            }

            public bool IsText
            {
                [MethodImpl(Inline)]
                get => Class.IsText;
            }

            public bool IsSegSpec
            {
                [MethodImpl(Inline)]
                get => Class.IsSegSpec;
            }

            public bool IsSeg
            {
                [MethodImpl(Inline)]
                get => Class.IsSeg;
            }

            public bool IsExpr
            {
                [MethodImpl(Inline)]
                get => Class.IsExpr;
            }

            [MethodImpl(Inline)]
            public bool Equals(CellType src)
                => Field == src.Field
                && Class == src.Class
                && Operator == src.Operator
                && DataType == src.DataType
                && EffectiveType == src.EffectiveType;

            public string Format()
                => format(this);

            public override string ToString()
                => Format();

            public static CellType Empty => default;
        }

        public static string format(in CellType src)
            => src.IsEmpty ? RP.Error
            : src.IsOperator
            ? string.Format("Operator ({0})", src.Operator)
            : src.DataType == src.EffectiveType
            ? string.Format("{0}:{1}", src.Class, src.DataType)
            : string.Format("{0}:{1} <: {2}", src.Class, src.EffectiveType, src.DataType);

    }
}