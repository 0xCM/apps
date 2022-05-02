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
        public readonly record struct RuleCell : IComparable<RuleCell>
        {
            public readonly CellKey Key;

            public readonly CellValue Value;

            [MethodImpl(Inline)]
            public RuleCell(CellKey key, CellValue value)
            {
                Key = key;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperator Operator()
            {
                var dst = RuleOperator.None;
                if(Value.IsExpr)
                    dst = Value.ToCellExpr().Operator;
                else if (Value.IsOperator)
                    dst = Value.AsOperator();
                return dst;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Value.Field;
            }

            public LogicClass Logic
            {
                [MethodImpl(Inline)]
                get => Key.Logic;
            }

            public bool IsOperator
            {
                [MethodImpl(Inline)]
                get => Value.IsOperator;
            }

            public bool IsNontermCall
            {
                [MethodImpl(Inline)]
                get => Value.IsNontermCall;
            }

            public byte CellIndex
            {
                [MethodImpl(Inline)]
                get => Key.Col;
            }

            public ushort RowIndex
            {
                [MethodImpl(Inline)]
                get => Key.Row;
            }

            public ushort TableIndex
            {
                [MethodImpl(Inline)]
                get => Key.Table;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => Rule.TableKind;
            }

            public RuleSig Rule
            {
                [MethodImpl(Inline)]
                get => Key.Rule;
            }

            public bool IsCellExpr
            {
                [MethodImpl(Inline)]
                get => Value.IsExpr;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public int CompareTo(RuleCell src)
                => Key.CompareTo(src.Key);

            public string Format()
                => XedRender.format(Value);

            public override string ToString()
                => Format();

            public static RuleCell Empty => default;
        }
    }
}