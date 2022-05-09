//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public struct TableDefRow
        {
            public const string TableName = "xed.rules.tables";

            public const byte FieldCount = 6;

            [Render(8)]
            public uint Seq;

            [Render(8)]
            public uint TableId;

            [Render(8)]
            public uint Index;

            [Render(8)]
            public RuleTableKind Kind;

            [Render(32)]
            public RuleName Name;

            [Render(1)]
            public TextBlock Statement;

            public static TableDefRow Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,8,32,1};
       }
    }
}