//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct CellMetrics
        {
            /// <summary>
            /// Specifies the number of indexed tables
            /// </summary>
            public ushort TableCount;

            /// <summary>
            /// Specifies the number of indexed rows
            /// </summary>
            public uint RowCount;

            /// <summary>
            /// Specifies the number of indexed cells
            /// </summary>
            public uint CellCount;

            /// <summary>
            /// Specifies the number of rows for each index-identified table
            /// </summary>
            public Index<ushort> RowCounts;
        }
    }
}