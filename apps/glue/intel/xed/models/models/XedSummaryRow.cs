//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
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