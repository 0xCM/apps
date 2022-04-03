//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct TableDefRow
        {
            public uint Seq;

            public uint Index;

            public uint TableId;

            public RuleSig Sig;

            public string[] Cells;

            public static TableDefRow Empty => default;

            public static string Header => string.Format("{0,-8} | {1,-8} | {2,-8} | {3,-8} | {4,-32} | {5}", "Seq", "TableId", "Index", "Kind", "Name", "Expression");
        }
    }
}