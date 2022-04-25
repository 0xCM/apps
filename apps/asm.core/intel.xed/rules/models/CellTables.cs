//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct CellTables
        {
            readonly Index<CellTable> Data;

            [MethodImpl(Inline)]
            public CellTables(CellTable[] src)
            {
                Data = src;
            }

            public Span<CellTable> Edit
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public ReadOnlySpan<CellTable> View
            {
                [MethodImpl(Inline)]
                get => Data.Edit;
            }

            public CellTable[] Storage
            {
                [MethodImpl(Inline)]
                get => Data.Storage;
            }

            public ref CellTable this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref CellTable this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public uint TableCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public uint RowCount()
                => Data.Select(x => x.RowCount).Storage.Sum();

            public uint CellCount()
                => Data.Select(x => x.CellCount()).Storage.Sum();

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Data.IsNonEmpty;
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator CellTables(CellTable[] src)
                => new CellTables(src);

            [MethodImpl(Inline)]
            public static implicit operator CellTable[](CellTables src)
                => src.Data;

            public static CellTables Empty => new CellTables(sys.empty<CellTable>());
        }
    }
}