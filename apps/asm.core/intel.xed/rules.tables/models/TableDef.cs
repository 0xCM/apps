//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct TableDef
        {
            public readonly ushort TableId;

            public readonly RuleSig Sig;

            public readonly Index<RowDef> Rows;

            public TableDef(ushort id, RuleSig sig, RowDef[] rows)
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

            public ref RowDef this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref RowDef this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }
        }
    }
}