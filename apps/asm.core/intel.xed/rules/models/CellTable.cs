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
                var cols = src.Rows.Select(row => fields(row).Count).Storage.Max();
                var dst = alloc<GridField>(cols*src.RowCount);
                var k=z8;
                for(var i=0; i<src.RowCount; i++)
                {
                    var _fields = fields(src[i]);
                    for(var j=0; j<_fields.Count; j++)
                        seek(dst, k++) = _fields[j];
                    for(var j=k; j<cols; j++)
                        seek(dst, k++) = new GridField(src.TableIndex, src[i].RowIndex, k, 0, 0);
                }
                return new GridFields((ushort)src.RowCount, (byte)cols, dst);
            }

            public static Index<GridField> fields(CellRow src)
                => src.Cells.Storage.Where(x => x.Field != 0).Mapi((i,f)
                    => new GridField(src.TableIndex, src.RowIndex, (byte)i, f.Field, (byte)XedFields.field(f.Field).FieldSize.DomainWidth));

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