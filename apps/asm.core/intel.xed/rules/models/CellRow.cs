//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellRow : IComparable<CellRow>
        {
            public readonly RuleSig TableSig;

            public readonly ushort TableIndex;

            public readonly ushort RowIndex;

            public readonly Index<RuleCell> Cells;

            [MethodImpl(Inline)]
            public CellRow(RuleSig sig, ushort tid, ushort rix, RuleCell[] src)
            {
                TableIndex = tid;
                RowIndex = rix;
                TableSig = sig;
                Cells = src;
            }

            [MethodImpl(Inline)]
            public FieldVector Fields()
            {
                var n = (byte)Cells.Count;
                var dst = FieldVector.init(n);
                for(var i=z8; i<n; i++)
                {
                    if(!Cells[i].IsOperator)
                        dst[i] = Cells[i].Field;
                }
                return dst;
            }

            public readonly uint Count
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public ref RuleCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref RuleCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Cells.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Cells.IsNonEmpty;
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            public int CompareTo(CellRow src)
            {
                var result = TableSig.CompareTo(src.TableSig);
                if(result == 0)
                    result = TableIndex.CompareTo(src.TableIndex);
                if(result == 0)
                    result = RowIndex.CompareTo(src.RowIndex);
                return result;
            }

            public static CellRow Empty => new CellRow(RuleSig.Empty, 0, 0, sys.empty<RuleCell>());
        }
    }
}