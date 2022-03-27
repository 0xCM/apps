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

            public const byte FieldCount = 19;

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

            public RuleTableCell Col7P;

            public RuleTableCell Col0C;

            public RuleTableCell Col1C;

            public RuleTableCell Col2C;

            public RuleTableCell Col3C;

            public RuleTableCell Col4C;

            public RuleTableCell Col5C;

            public RuleTableCell Col6C;

            public RuleTableCell Col7C;

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
                        7 => Col7P,

                        8 => Col0C,
                        9 => Col1C,
                        10 => Col2C,
                        11 => Col3C,
                        12 => Col4C,
                        13 => Col5C,
                        14 => Col6C,
                        15 => Col7C,
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
                            Col7P = value;
                        break;

                        case 8:
                            Col0C = value;
                        break;
                        case 9:
                            Col1C = value;
                        break;
                        case 10:
                            Col2C = value;
                        break;
                        case 11:
                            Col3C = value;
                        break;
                        case 12:
                            Col4C = value;
                        break;
                        case 13:
                            Col5C = value;
                        break;
                        case 14:
                            Col6C = value;
                        break;
                        case 15:
                            Col7C = value;
                        break;
                    };
                }
            }
            public int CompareTo(RuleTableRow src)
            {
                var result = ((byte)TableKind).CompareTo((byte)src.TableKind);
                if(result == 0)
                {
                    result = TableName.CompareTo(src.TableName);
                    if(result == 0)
                        result = RowIndex.CompareTo(src.RowIndex);
                }
                return result;
            }

            public static RuleTableRow Empty => default;
        }
    }
}