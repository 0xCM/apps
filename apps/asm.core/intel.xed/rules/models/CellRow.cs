//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellRow
        {
            public readonly RuleSig TableSig;

            public readonly ushort TableId;

            public readonly ushort RowIndex;
            public readonly Index<KeyedCell> Cells;

            [MethodImpl(Inline)]
            public CellRow(RuleSig sig, ushort tid, ushort rix, KeyedCell[] src)
            {
                TableId = tid;
                RowIndex = rix;
                TableSig = sig;
                Cells = src;
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

            public ref KeyedCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref KeyedCell this[int i]
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

            public static CellRow Empty => new CellRow(RuleSig.Empty, 0, 0, sys.empty<KeyedCell>());
        }
    }
}