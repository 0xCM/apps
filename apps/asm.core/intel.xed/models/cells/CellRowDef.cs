//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellRowDef
        {
            public readonly ushort Table;

            public readonly ushort Index;

            public readonly Index<CellDef> Cells;

            [MethodImpl(Inline)]
            public CellRowDef(ushort table, ushort index, CellDef[] cells)
            {
                Table = table;
                Index = index;
                Cells = cells;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public ref CellDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref CellDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }
        }
    }
}