//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    using static XedModels;

    partial class XedGrids
    {
        public readonly struct LogicRow
        {
            readonly Index<LogicCell> Cells;

            [MethodImpl(Inline)]
            public LogicRow(RuleSig rule, LogicCell[] src)
            {
                Cells = src;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public ref LogicCell this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref LogicCell this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }
        }
    }
}