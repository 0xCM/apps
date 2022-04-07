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
            public const string TableName = "xed.fields.reflected";

            public const byte FieldCount = 9;

            public ushort Index;

            public Identifier FieldName;

            public FieldKind FieldKind;

            public ushort EffectiveWidth;

            public ushort DataWidth;

            public ushort TotalSize;

            public Identifier DeclaredType;

            public Identifier EffectiveType;

            public TextBlock Description;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,24,12,12,12,22,22,1};
        }
    }
}