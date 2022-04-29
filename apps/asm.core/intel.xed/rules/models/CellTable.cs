//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public readonly struct CellTable : IComparable<CellTable>
        {
            public static GridFields fields(in CellTable src)
            {
                var cols = (byte)src.Rows.Select(row => fields(row).Count).Storage.Max();
                var dst = alloc<GridField>(cols*src.RowCount);
                var k=z8;
                for(var i=0; i<src.RowCount; i++)
                {
                    var fields = CellTable.fields(src[i]);
                    for(var j=0; j<fields.Count; j++, k++)
                        seek(dst, k) = fields[j];
                    for(var j=k; j<cols; j++, k++)
                        seek(dst, k) = GridField.Empty;
                }
                return new GridFields(src.Sig, (ushort)src.RowCount, cols, dst);
            }

            public GridFields Grid()
                => fields(this);

            [MethodImpl(Inline)]
            static DataSize size(in ReflectedField src)
                => new DataSize(src.NativeWidth, src.PackedWidth.Packed);

            public static Index<GridField> fields(CellRow src)
            {
                return
                    src.Cells.Storage
                        //.Where(x => x.Field != 0)
                        .Mapi((i,f) => new GridField(src.TableIndex, src.RowIndex, (byte)i, f.Field,
                            size(XedFields.field(f.Field))));
            }

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

            public int CompareTo(CellTable src)
            {
                var result = Sig.CompareTo(src.Sig);
                if(result == 0)
                    result = TableIndex.CompareTo(src.TableIndex);
                return result;
            }

            public static CellTable Empty => new CellTable(RuleSig.Empty, 0, sys.empty<CellRow>());
        }
    }
}