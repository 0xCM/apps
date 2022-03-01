//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [Record(TableName)]
        public struct RuleFieldSpec
        {
            public const string TableName = "xed.rules.fields";

            public const byte FieldCount = 5;

            public ushort Pos;

            public Identifier Name;

            public FieldKind Kind;

            public ushort Width;

            public Identifier Type;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,24,8,1};
        }
    }
}