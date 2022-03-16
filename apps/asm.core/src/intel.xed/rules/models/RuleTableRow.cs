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
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public struct RuleTableRow : IComparable<RuleTableRow>
        {
            public const string TableId = "xed.rules.tables";

            public const byte FieldCount = 17;

            public const byte ColCount = FieldCount - 3;

            public RuleTableKind TableKind;

            public string TableName;

            public uint RowIndex;

            public RuleTableCell Col0P;

            public RuleTableCell Col1P;

            public RuleTableCell Col2P;

            public RuleTableCell Col3P;

            public RuleTableCell Col4P;

            public RuleTableCell Col5P;

            public RuleTableCell Col6P;

            public RuleTableCell Col0C;

            public RuleTableCell Col1C;

            public RuleTableCell Col2C;

            public RuleTableCell Col3C;

            public RuleTableCell Col4C;

            public RuleTableCell Col5C;

            public RuleTableCell Col6C;

            public RuleTableCell this[int index]
            {
                get
                {
                    return index switch
                    {
                        0 => Col0P,
                        1 => Col1P,
                        2 => Col2P,
                        3 => Col3P,
                        4 => Col4P,
                        5 => Col5P,
                        6 => Col6P,

                        7 => Col0C,
                        8 => Col1C,
                        9 => Col2C,
                        10 => Col3C,
                        11 => Col4C,
                        12 => Col5C,
                        13 => Col6C,
                        _ => RuleTableCell.Empty
                    };
                }
                set
                {
                    switch(index)
                    {
                        case 0:
                            Col0P = value;
                        break;
                        case 1:
                            Col1P = value;
                        break;
                        case 2:
                            Col2P = value;
                        break;
                        case 3:
                            Col3P = value;
                        break;
                        case 4:
                            Col4P = value;
                        break;
                        case 5:
                            Col5P = value;
                        break;
                        case 6:
                            Col6P = value;
                        break;

                        case 7:
                            Col0C = value;
                        break;
                        case 8:
                            Col1C = value;
                        break;
                        case 9:
                            Col2C = value;
                        break;
                        case 10:
                            Col3C = value;
                        break;
                        case 11:
                            Col4C = value;
                        break;
                        case 12:
                            Col5C = value;
                        break;
                        case 13:
                            Col6C = value;
                        break;
                    };
                }
            }

            public static void RenderWidths(in RuleTableRows src, Span<byte> dst)
            {
                RenderWidths(src.TableSig, src.Data, dst);
            }

            public static void RenderWidths(RuleSig sig, ReadOnlySpan<RuleTableRow> data, Span<byte> dst)
            {
                seek(dst, 0) = 12;
                if(skip(dst,1) != 0)
                    seek(dst, 1) = max((byte)(sig.Name.Length + 1), skip(dst,1));
                else
                    seek(dst, 1) = max((byte)(sig.Name.Length + 1), (byte)12);
                seek(dst, 2) = 12;
                RenderWidths(data, dst);
            }

            public static void RenderWidths(ReadOnlySpan<RuleTableRow> src, Span<byte> dst)
            {
                const byte Offset = 3;

                for(var i=Offset; i<FieldCount; i++)
                    seek(dst,i) = max((byte)10, skip(dst,i));

                var count = src.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var row = ref skip(src,i);
                    for(byte j=0,k=Offset; j<FieldCount; j++, k++)
                    {
                        var cell = row[j];
                        var width = cell.Format().Length;
                        if(width > skip(dst,k))
                            seek(dst,k) = (byte)width;
                    }
                }
            }

            public int CompareTo(RuleTableRow src)
            {
                var result = TableName.CompareTo(src.TableName);
                if(result == 0)
                    result = RowIndex.CompareTo(src.RowIndex);
                return result;
            }

            public static RuleTableRow Empty => default;
        }
    }
}