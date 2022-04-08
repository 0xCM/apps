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
        public readonly struct CellType
        {
            [MethodImpl(Inline)]
            public static CellType @operator(RuleOperator op)
                => new CellType(0, RuleCellKind.Operator, op, asci16.Null, 0, asci16.Null, 0);

            [MethodImpl(Inline)]
            public static CellType keyword()
                => new CellType(0, RuleCellKind.Keyword, RuleOperator.None, asci16.Null, 0, asci16.Null, 0);

            [MethodImpl(Inline)]
            public static CellType @string()
                => new CellType(0, RuleCellKind.String, RuleOperator.None, asci16.Null, 0, asci16.Null, 0);

            [MethodImpl(Inline)]
            public static CellType @char()
                => new CellType(0, RuleCellKind.String, RuleOperator.None, asci16.Null, 0, asci16.Null, 0);

            [MethodImpl(Inline)]
            public static CellType segspec()
                => new CellType(0, RuleCellKind.SegSpec, RuleOperator.None, asci16.Null, 0, asci16.Null, 0);

            public readonly FieldKind Field;

            public readonly CellClass Class;

            public readonly RuleOperator Operator;

            public readonly asci16 DataType;

            public readonly byte DataWidth;

            public readonly asci16 EffectiveType;

            public readonly byte EffectiveWidth;

            [MethodImpl(Inline)]
            public CellType(FieldKind field, CellClass @class, RuleOperator op, asci16 data, byte wdata, asci16 eff, byte weff)
            {
                Field = field;
                Class = @class;
                Operator = op;
                DataType = data;
                DataWidth = wdata;
                EffectiveType = eff;
                EffectiveWidth = weff;
            }

            public bool IsBit
            {
                [MethodImpl(Inline)]
                get => EffectiveType == nameof(bit);
            }

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

            public bool IsSegLiteral
            {
                [MethodImpl(Inline)]
                get => Class.IsSegLiteral;
            }

            public bool IsSegVar
            {
                [MethodImpl(Inline)]
                get => Class.IsSegVar;
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
                => CellRender.format(this);

            public override string ToString()
                => Format();

            public static CellType Empty
                => new CellType(FieldKind.INVALID, CellClass.Empty, RuleOperator.None, asci16.Null,0, asci16.Null, 0);
        }
    }
}