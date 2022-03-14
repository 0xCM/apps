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
        public struct RuleTableRow
        {
            public const string TableName = "xed.rules.tables";

            public const byte FieldCount = 13;

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

            public static RuleTableRow Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,16,16,16,16,16,16,16,16,16,16,16,16};
        }
    }
}