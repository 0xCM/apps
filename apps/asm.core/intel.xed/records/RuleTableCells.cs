//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct RuleTableCells
        {
            public const byte MaxCount = 16;

            public byte Count;

            public RuleTableCell Cell0;

            public RuleTableCell Cell1;

            public RuleTableCell Cell2;

            public RuleTableCell Cell3;

            public RuleTableCell Cell4;

            public RuleTableCell Cell5;

            public RuleTableCell Cell6;

            public RuleTableCell Cell7;

            public RuleTableCell Cell8;

            public RuleTableCell Cell9;

            public RuleTableCell Cell10;

            public RuleTableCell Cell11;

            public RuleTableCell Cell12;

            public RuleTableCell Cell13;

            public RuleTableCell Cell14;

            public RuleTableCell Cell15;

            public string Format()
                => RuleCellRender.format(this);

            public override string ToString()
                => Format();
            public static RuleTableCells Empty => default;

            public RuleTableCell this[int index]
            {
                get
                {
                    return index switch
                    {
                        0 => Cell0,
                        1 => Cell1,
                        2 => Cell2,
                        3 => Cell3,
                        4 => Cell4,
                        5 => Cell5,
                        6 => Cell6,
                        7 => Cell7,

                        8 => Cell8,
                        9 => Cell9,
                        10 => Cell10,
                        11 => Cell11,
                        12 => Cell12,
                        13 => Cell13,
                        14 => Cell14,
                        15 => Cell15,
                        _ => RuleTableCell.Empty
                    };
                }
                set
                {
                    switch(index)
                    {
                        case 0:
                            Cell0 = value;
                        break;
                        case 1:
                            Cell1 = value;
                        break;
                        case 2:
                            Cell2 = value;
                        break;
                        case 3:
                            Cell3 = value;
                        break;
                        case 4:
                            Cell4 = value;
                        break;
                        case 5:
                            Cell5 = value;
                        break;
                        case 6:
                            Cell6 = value;
                        break;
                        case 7:
                            Cell7 = value;
                        break;

                        case 8:
                            Cell8 = value;
                        break;
                        case 9:
                            Cell9 = value;
                        break;
                        case 10:
                            Cell10 = value;
                        break;
                        case 11:
                            Cell11 = value;
                        break;
                        case 12:
                            Cell12 = value;
                        break;
                        case 13:
                            Cell13 = value;
                        break;
                        case 14:
                            Cell14 = value;
                        break;
                        case 15:
                            Cell15 = value;
                        break;
                    };
                }
            }
        }
    }
}