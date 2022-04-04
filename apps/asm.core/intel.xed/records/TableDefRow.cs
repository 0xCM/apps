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

            public uint Seq;

            public uint TableId;

            public uint Index;

            public RuleTableKind Kind;

            public asci32 Name;

            public RuleGridRow Statement;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,8,32,1};

            public static TableDefRow Empty => default;
       }
    }
}