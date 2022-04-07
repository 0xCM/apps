//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class CellTableDef
        {
            public readonly ushort TableId;

            public readonly RuleSig Sig;

            public readonly Index<CellRowDef> Rows;

            public CellTableDef(ushort id, RuleSig sig, CellRowDef[] rows)
            {
                TableId = id;
                Sig = sig;
                Rows = rows;
            }

            public uint RowCount
            {
                [MethodImpl(Inline)]
                get => Rows.Count;
            }

            public ref CellRowDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref CellRowDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }
        }
    }
}