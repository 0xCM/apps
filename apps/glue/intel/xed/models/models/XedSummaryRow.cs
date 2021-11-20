//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct XedSummaryRow : IRecord<XedSummaryRow>
    {
        public const string TableId = "xed.summary";

        public TextBlock Class;

        public TextBlock Category;

        public TextBlock Extension;

        public TextBlock IsaSet;

        public TextBlock IForm;

        public BinaryCode BaseCode;

        public TextBlock Mod;

        public TextBlock Reg;

        public TextBlock Pattern;

        public TextBlock Operands;
    }
}