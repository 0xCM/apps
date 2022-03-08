//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName)]
        public struct RuleFieldSpec
        {
            public const string TableName = "xed.rules.fields";

            public const byte FieldCount = 7;

            public ushort Pos;

            public Identifier Name;

            public FieldKind Kind;

            public ushort FieldWidth;

            public ushort DataWidth;

            public ushort TotalSize;

            public Identifier Type;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,24,12,12,12,1};
        }
    }
}