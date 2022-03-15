//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public struct RuleTableRow
        {
            public const string TableId = "xed.rules.tables";

            public const byte FieldCount = 14;

            public const byte ColCount = 12;

            public string TableName;

            public byte RowIndex;

            public RuleTableCell Col0P;

            public RuleTableCell Col1P;

            public RuleTableCell Col2P;

            public RuleTableCell Col3P;

            public RuleTableCell Col4P;

            public RuleTableCell Col5P;

            public RuleTableCell Col0C;

            public RuleTableCell Col1C;

            public RuleTableCell Col2C;

            public RuleTableCell Col3C;

            public RuleTableCell Col4C;

            public RuleTableCell Col5C;

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

                        6 => Col0C,
                        7 => Col1C,
                        8 => Col2C,
                        9 => Col3C,
                        10 => Col4C,
                        11 => Col5C,
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
                            Col0C = value;
                        break;
                        case 7:
                            Col1C = value;
                        break;
                        case 8:
                            Col2C = value;
                        break;
                        case 9:
                            Col3C = value;
                        break;
                        case 10:
                            Col4C = value;
                        break;
                        case 11:
                            Col5C = value;
                        break;
                    };
                }
            }

            public static RuleTableRow Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,24,24,24,24,24,24,24,24,24,24,24,24};
        }
    }
}