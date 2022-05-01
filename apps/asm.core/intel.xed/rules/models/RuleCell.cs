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
            public delegate asci32 AsciFormatter(in RuleCell src);

            public static AsciFormatter formatter()
            {
                return Calc;
                asci32 Calc(in RuleCell src)
                    => XedRender.format(src.Value);
            }

            public readonly CellKey Key;

            public readonly InstField Value;

            [MethodImpl(Inline)]
            public RuleCell(CellKey key, InstField value)
            {
                Key = key;
                Value = value;
            }

            [MethodImpl(Inline)]
            public RuleOperator Operator()
            {
                var dst = RuleOperator.None;
                if(Value.IsCellExpr)
                    dst = Value.ToCellExpr().Operator;
                else if (Value.IsOperator)
                    dst = Value.AsOperator();
                return dst;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Value.FieldKind;
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
                get => Value.IsCellExpr;
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
            // {
            //     var dst = EmptyString;
            //     if(IsCellExpr)
            //     {
            //         var expr = Value.ToCellExpr();
            //         dst = expr.Format();
            //     }
            //     else
            //         dst = XedRender.atomic(Value);

            //     return dst;
            // }

            public override string ToString()
                => Format();

            public static RuleCell Empty => default;
        }
    }
}