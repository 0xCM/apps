//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellTable
        {
            public readonly RuleSig Sig;

            public readonly ushort TableIndex;

            public readonly Index<CellRow> Rows;

            [MethodImpl(Inline)]
            public CellTable(RuleSig sig, ushort tix, CellRow[] src)
            {
                Sig = sig;
                TableIndex = tix;
                Rows = src;
            }

            public ref CellRow this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public ref CellRow this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Rows[i];
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Rows.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Rows.IsNonEmpty;
            }

            public readonly uint Count
            {
                [MethodImpl(Inline)]
                get => Rows.Count;
            }

            public uint RowCount
            {
                [MethodImpl(Inline)]
                get => Rows.Count;
            }

            public uint CellCount()
                => Rows.Select(x => x.CellCount).Storage.Sum();

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            public static CellTable Empty => new CellTable(RuleSig.Empty, 0, sys.empty<CellRow>());
        }
    }
}