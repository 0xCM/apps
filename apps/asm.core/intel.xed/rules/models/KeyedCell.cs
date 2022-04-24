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
        public readonly record struct KeyedCell : IComparable<KeyedCell>
        {
            public readonly ushort LinearIndex;

            public readonly CellKey Key;

            public readonly InstField Value;

            [MethodImpl(Inline)]
            public KeyedCell(uint lix, CellKey key, InstField value)
            {
                LinearIndex = (ushort)lix;
                Key = key;
                Value = value;
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

            public byte CellIndex
            {
                [MethodImpl(Inline)]
                get => Key.CellIndex;
            }

            public ushort RowIndex
            {
                [MethodImpl(Inline)]
                get => Key.RowIndex;
            }

            public ushort TableId
            {
                [MethodImpl(Inline)]
                get => Key.TableId;
            }

            public RuleSig TableSig
            {
                [MethodImpl(Inline)]
                get => Key.TableSig;
            }

            public bool IsFieldExpr
            {
                [MethodImpl(Inline)]
                get => Value.IsFieldExpr;
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
            public int CompareTo(KeyedCell src)
                => Key.CompareTo(src.Key);

            public string Format()
            {
                var dst = EmptyString;
                if(IsFieldExpr)
                {
                    var expr = Value.ToFieldExpr();
                    dst = expr.Format();
                }
                else
                    dst = XedRender.format(Value);

                return dst;
            }

            public override string ToString()
                => Format();

            public static KeyedCell Empty => default;
        }
    }
}